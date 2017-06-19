using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Jokes.APIs.DataContext;
using Jokes.Entities;

namespace Jokes.APIs.Controllers
{
    [Authorize]
    public class PostedJokesController : ApiController
    {
        private JokesDb db = new JokesDb();
        private AccountController account = new AccountController();

        // GET: api/PostedJokes
        [AllowAnonymousAttribute]
        public IQueryable<PostedJoke> GetPostedJokes()
        {
            return db.PostedJokes.Where(a=>a.IsHideen == false)
                 .OrderByDescending(a => a.PostedDate);
        }

        // GET: api/PostedJokes/userID
        [AllowAnonymousAttribute]
        [Route("~/api/PostedJokes/GetByUser/{userID}")]
        [ResponseType(typeof(PostedJoke))]
        public IQueryable<PostedJoke> GetPostedJokesByUser(string userID)
        {
            return db.PostedJokes
                .Where(a => a.PostedBy == userID)
                .OrderByDescending(a => a.PostedDate);
        }

        // GET: api/PostedJokes/5
        [AllowAnonymousAttribute]
        [ResponseType(typeof(PostedJoke))]
        public IHttpActionResult GetPostedJoke(int id)
        {
            PostedJoke postedJoke = db.PostedJokes.Find(id);
            if (postedJoke == null)
            {
                return NotFound();
            }

            return Ok(postedJoke);
        }

        // PUT: api/PostedJokes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPostedJoke(int id, PostedJoke postedJoke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postedJoke.JokeId)
            {
                return BadRequest();
            }

            db.Entry(postedJoke).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostedJokeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // PUT: api/PostedJokes/5

        [Authorize(Roles ="Administrator")]
        [HttpPut]
        [Route("~/api/PostedJokes/Hide/{Id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult HideJoke(int id)
        {
            try
            {
                var postedJoke = db.PostedJokes.Find(id);
                if (postedJoke != null)
                {
                    postedJoke.IsHideen = true;
                    db.Entry(postedJoke).State = EntityState.Modified;
                    db.SaveChanges();

                    return Ok(new { Success = true, Content = "Joke Hidden" });
                }

            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Ok(new { Success = false, Content = ex.Message });
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // PUT: api/PostedJokes/5
        [HttpPut]
        [Route("~/api/PostedJokes/Vote/{Id:int}/{up:bool}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Vote(int id, bool up)
        {
            try
            {
                var currentJoke = db.PostedJokes.Find(id);
                if (currentJoke != null)
                {
                    if (up == true)
                        currentJoke.UpVotes++;
                    else currentJoke.DownVotes++;
                    db.Entry(currentJoke).State = EntityState.Modified;

                    var vote = new Vote();
                    vote.Joke = currentJoke;
                    vote.PostedDate = DateTime.Now;
                    vote.VotedBy = account.UserIdentityId;
                    db.Votes.Add(vote);
                    db.SaveChanges();

                    return Ok(new { Success = true, Content = "Joke Hidden" });
                }
                else
                {
                    return Ok(new { Success = false, Content = "Joke Not found" });
                }
            }
            catch (DbUpdateConcurrencyException)
            {    
                if (!PostedJokeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // PUT: api/PostedJokes/5
        [Authorize]
        [HttpPut]
        [Route("~/api/PostedJokes/PostComment/id/comment")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PostComment(int id, string content)
        {
            try
            {
                var currentJoke = db.PostedJokes.Find(id);
                if (currentJoke != null && !string.IsNullOrEmpty(content))
                {
               
                    var comment = new Comment();
                    comment.Joke = currentJoke;
                    comment.PostedDate = DateTime.Now;
                    comment.IsHideen = false;
                    comment.Content = content;
                    comment.PostedBy = account.UserIdentityId;
                    db.Comments.Add(comment);
                    db.SaveChanges();

                    return Ok(new { Success = true, Content = "Comment Added Succefully" });
                }
                else
                {
                    return Ok(new { Success = false, Content = "Joke Not found" });
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostedJokeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }


        // POST: api/PostedJokes
        [ResponseType(typeof(PostedJoke))]
        public IHttpActionResult PostPostedJokes(PostedJoke postedJoke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            postedJoke.PostedDate = DateTime.Now;
            postedJoke.DownVotes = 0;
            postedJoke.UpVotes = 0;
            postedJoke.IsHideen = false;
            postedJoke.PostedBy =  account.UserIdentityId;
            
            db.PostedJokes.Add(postedJoke);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = postedJoke.JokeId }, postedJoke);
        }

        // POST: api/PostedJokes
       /* [ResponseType(typeof(PostedJoke))]
        public IHttpActionResult PostPostedJoke(PostedJoke postedJoke)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PostedJokes.Add(postedJoke);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = postedJoke.JokeId }, postedJoke);
        }
        */
        // DELETE: api/PostedJokes/5
        [ResponseType(typeof(PostedJoke))]
        public IHttpActionResult DeletePostedJoke(int id)
        {
            PostedJoke postedJoke = db.PostedJokes.Find(id);
            if (postedJoke == null)
            {
                return NotFound();
            }

            db.PostedJokes.Remove(postedJoke);
            db.SaveChanges();

            return Ok(postedJoke);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PostedJokeExists(int id)
        {
            return db.PostedJokes.Count(e => e.JokeId == id) > 0;
        }
    }
}
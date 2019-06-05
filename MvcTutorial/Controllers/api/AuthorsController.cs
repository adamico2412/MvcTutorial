using AutoMapper;
using MvcTutorial.DAL;
using MvcTutorial.Models;
using MvcTutorial.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MvcTutorial.Controllers.api
{
    public class AuthorsController : ApiController
    {
        private readonly BookContext db = new BookContext();

        // GET: api/Authors
        public ResultList<AuthorViewModel> Get([FromUri] QueryOptions queryOptions)
        {
            var authors = db.Authors.OrderBy(queryOptions.Sort);

            queryOptions.TotalPages = (int)Math.Ceiling((double)authors.Count() / queryOptions.PageSize);

            var result = authors.ToList()
                                .Skip((queryOptions.CurrentPage - 1) * queryOptions.PageSize)
                                .Take(queryOptions.PageSize);

            return new ResultList<AuthorViewModel>(Mapper.Map<List<Author>, List<AuthorViewModel>>(result.ToList()), queryOptions);
        }

        //PUT: api/Authors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(AuthorViewModel author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(Mapper.Map<AuthorViewModel, Author>(author)).State = EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        //POST: api/Authors
        [ResponseType(typeof(AuthorViewModel))]
        public IHttpActionResult Post(AuthorViewModel author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Authors.Add(Mapper.Map<AuthorViewModel, Author>(author));
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = author.Id }, author);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

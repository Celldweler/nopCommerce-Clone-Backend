using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NopClone.Data.Context;
using NopClone.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NopClone.WebApi.Controllers
{
    public class CategoriesController : ApiBaseController
    {
        private NopCloneDataContext _ctx;

        public CategoriesController(NopCloneDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            return _ctx.Categories
                .Include(x => x.SubCategories)
                .Include(x => x.Image)
                .Where(x => x.ParentId == null)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.ParentId,
                    x.Image,
                    x.Depth,
                    x.ShowOnHomePage,
                    x.IncludeInTopMenu,
                    x.ViewPath,
                    CreatedAt = x.CreatedAt.ToShortDateString(),
                    SubCategories = x.SubCategories.Select(y => y.Name)
                })
                .AsEnumerable();
        }

        [HttpGet("{categoryId}/getOne")]
        public object Get(string categoryId)
        {
            return _ctx.Categories
                .Include(x => x.SubCategories)
                .Include(x => x.Image)
                .Where(x => x.ParentId == null && x.Id.Equals(categoryId))
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.ParentId,
                    x.Image,
                    x.Depth,
                    x.ShowOnHomePage,
                    x.IncludeInTopMenu,
                    x.ViewPath,
                    CreatedAt = x.CreatedAt.ToShortDateString(),
                    SubCategories = x.SubCategories.Select(y => y.Name)
                })
                .Single();
        }

        [HttpGet("{categoryId}/subOne")]
        public IActionResult GetSingleSub(string categoryId)
        {
            var subCategory = _ctx.Categories
                .Single(x => x.Id.Equals(categoryId));

            return Ok(subCategory);
        }

        //sub categories
        [HttpGet("{parentId}/subs")]
        public IActionResult Subs(string parentId)
        {
            var subCategories = _ctx.Categories
                .Include(x => x.Image)
                .Where(x => x.Parent.Name.Equals(parentId))
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.ParentId,
                    x.Image,
                    x.Depth,
                    x.ShowOnHomePage,
                    x.IncludeInTopMenu,
                    x.ViewPath,
                    CreatedAt = x.CreatedAt.ToShortDateString(),
                    //SubCategories = x.SubCategories.Select(y => y.Name)
                })
                .AsEnumerable();

            return Ok(subCategories);
        }

        //sub categories
        //[HttpGet("{parentName}/subsByName")]
        //public IActionResult Subs(string parentName)
        //{
        //    var subCategories = _ctx.Categories
        //        .Include(x => x.Image)
        //        .Where(x => x.Parent.Name == parentName)
        //        .Select(x => new
        //        {
        //            x.Id,
        //            x.Name,
        //            x.ParentId,
        //            x.Image,
        //            x.Depth,
        //            x.ShowOnHomePage,
        //            x.IncludeInTopMenu,
        //            CreatedAt = x.CreatedAt.ToShortDateString(),
        //            //SubCategories = x.SubCategories.Select(y => y.Name)
        //        })
        //        .AsEnumerable();

        //    return Ok(subCategories);
        //}

        [HttpGet("{count}")]
        public IEnumerable<object> Get(int count)
        {
            return _ctx.Categories
                .Include(x => x.SubCategories)
                .Include(x => x.Image)
                .Where(x => x.ParentId == null && x.Image != null)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.ParentId,
                    x.Image,
                    CreatedAt = x.CreatedAt.ToShortDateString(),
                    SubCategories = x.SubCategories.Select(y => y.Name)
                })
                .Take(count)
                .AsEnumerable();
        }
    }
}

namespace MoiteRecepti.Web.ViewModels.Recipe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using MoiteRecepti.Data.Models;
    using MoiteRecepti.Services.Mapping;

    public class SingleRecipeViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AddedByUserUserName { get; set; }

        public string ImageUrl { get; set; }

        public string Instructions { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public TimeSpan CookingTime { get; set; }

        public int PortionsCount { get; set; }

        public double AverageVote { get; set; }

        public IEnumerable<IngredientsViewModel> Ingredients { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, SingleRecipeViewModel>()
                .ForMember(x => x.AverageVote, opt =>
                opt.MapFrom(x => x.Votes.Count() == 0 ? 0 : x.Votes.Average(v => v.Value)))
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(r =>
                    r.Images.FirstOrDefault().RemoteImageUrl != null ?
                    r.Images.FirstOrDefault().RemoteImageUrl :
                    "/images/recipes/" + r.Images.FirstOrDefault().Id + "." + r.Images.FirstOrDefault().Extension));
        }
    }
}

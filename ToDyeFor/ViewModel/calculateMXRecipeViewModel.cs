using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDyeFor.ViewModel
{
    public class calculateMXRecipeViewModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        //Not sure if DateTime is needed in the ViewModel
        [BsonElement("created-date")]
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime CreatedDate { get; set; }

        [BsonElement("updated-date")]
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime UpdatedDate { get; set; }

        //user input
        [Required(ErrorMessage = "Please enter a recipe name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "How deep do you want the color to be?")]
        public double ShadeDepth { get; set; }

        [Required(ErrorMessage = "How much fabric are you dyeing?")]
        public double FabricWeight { get; set; }

        [Required(ErrorMessage = "Which MX Dye color are you using?")]
        public string DyeColor { get; set; }

        //ingredients
        public double Salt { get; set; }

        public double SodaAsh { get; set; }

        public double Water { get; set; }

        public double Dye { get; set; }

        public calculateMXRecipeViewModel(string name, double shadeDepth, double fabricWeight, string dyeColor)
        {
            Name = name;
            ShadeDepth = shadeDepth;
            FabricWeight = fabricWeight;
            DyeColor = dyeColor;
            Salt = .5 * fabricWeight;
            SodaAsh = .09 * fabricWeight;
            Water = 20 * fabricWeight;
            Dye = shadeDepth * fabricWeight;
        }

        public calculateMXRecipeViewModel() { }




    }
}

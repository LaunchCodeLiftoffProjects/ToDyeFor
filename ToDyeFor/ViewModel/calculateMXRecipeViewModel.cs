
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDyeFor.ViewModel
{
    public class calculateMXRecipeViewModel
    {

        public int Id { get; set; }

        //Not sure if DateTime is needed in the ViewModel
        public DateTime CreatedDate { get; set; }

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
        //public double Salt { get; set; }

        //public double SodaAsh { get; set; }

        //public double Water { get; set; }

        //public double Dye { get; set; }

        public calculateMXRecipeViewModel(string name, double shadeDepth, double fabricWeight, string dyeColor)
        {
            Name = name;
            ShadeDepth = shadeDepth;
            FabricWeight = fabricWeight;
            DyeColor = dyeColor;
            //SodaAsh = .09 * fabricWeight;
            //Water = 20 * fabricWeight;
            //Dye = shadeDepth * fabricWeight;
        }

        public calculateMXRecipeViewModel() { }

        public double Salt()
        {
            return FabricWeight * .5;
        }

        public double SodaAsh()
        {
            return .09 * FabricWeight;
        }

        public double Water()
        {
            return 20 * FabricWeight;
        }

        public double Dye()
        {
            return ShadeDepth * FabricWeight;
        }


    }
}

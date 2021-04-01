
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToDyeFor.Models;

namespace ToDyeFor.ViewModel
{
    public class CalculateMXRecipeViewModel
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
        [Range(1, double.MaxValue, ErrorMessage = "Please enter valid weight")]
        public double FabricWeight { get; set; }

        [Required(ErrorMessage = "Which MX Dye color are you using?")]
        public string DyeColor { get; set; }

        public FabricType Fabric { get; set; }//this will be used as a tag used in search check box or radio

        public ColorType Color { get; set; }//this will be used as a tag used in search check box

        public List<SelectListItem> ColorTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(ColorType.Red.ToString(), ((int)ColorType.Red).ToString()),
            new SelectListItem(ColorType.Orange.ToString(), ((int)ColorType.Orange).ToString()),
            new SelectListItem(ColorType.Yellow.ToString(), ((int)ColorType.Yellow).ToString()),
            new SelectListItem(ColorType.Green.ToString(), ((int)ColorType.Green).ToString()),
            new SelectListItem(ColorType.Blue.ToString(), ((int)ColorType.Blue).ToString()),
            new SelectListItem(ColorType.Purple.ToString(), ((int)ColorType.Purple).ToString()),
            new SelectListItem(ColorType.Black.ToString(), ((int)ColorType.Black).ToString())
        };


        public List<SelectListItem> FabricTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(FabricType.Cotton.ToString(), ((int)FabricType.Cotton).ToString()),
            new SelectListItem(FabricType.Linen.ToString(), ((int)FabricType.Linen).ToString()),
            new SelectListItem(FabricType.Hemp.ToString(), ((int)FabricType.Hemp).ToString()),
            new SelectListItem(FabricType.Jute.ToString(), ((int)FabricType.Jute).ToString()),
            new SelectListItem(FabricType.Sisal.ToString(), ((int)FabricType.Sisal).ToString()),
            new SelectListItem(FabricType.Rayon.ToString(), ((int)FabricType.Rayon).ToString()),
            new SelectListItem(FabricType.Silk.ToString(), ((int)FabricType.Silk).ToString()),
            new SelectListItem(FabricType.Wool.ToString(), ((int)FabricType.Wool).ToString())
        };
        public CalculateMXRecipeViewModel(string name, double shadeDepth, double fabricWeight, string dyeColor)
        {
            Name = name;
            ShadeDepth = shadeDepth;
            FabricWeight = fabricWeight;
            DyeColor = dyeColor;

        }

        public CalculateMXRecipeViewModel() { }

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
            return (ShadeDepth/100) * FabricWeight;
        }


    }
}
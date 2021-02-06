
using System;

namespace ToDyeFor.Models
{
    public class MXRecipe
    {
        public int Id { get; set; }

        //How to use with SQL: https://www.entityframeworktutorial.net/faq/set-created-and-modified-date-in-efcore.aspx
        //to just get date only in code use:  DateTime.Now
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        //user input

        public string Name { get; set; }


        public double ShadeDepth { get; set; }


        public double FabricWeight { get; set; }


        public string DyeColor { get; set; }

        //ingredients

        public double Salt { get; set; }


        public double SodaAsh { get; set; }


        public double Water { get; set; }


        public double Dye { get; set; }


    }
}
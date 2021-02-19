
using System;

namespace ToDyeFor.Models
{
    public class MXRecipe
    {
        public int Id { get; set; }

        //How to use with SQL: https://www.entityframeworktutorial.net/faq/set-created-and-modified-date-in-efcore.aspx

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        //user input

        public string Name { get; set; }//user can create a personalized recipe name


        public double ShadeDepth { get; set; }


        public double FabricWeight { get; set; }


        public string DyeColor { get; set; }//user enters specific dye name (from manufacturer) 

        public FabricType Fabric { get; set; }//this will be used as a tag used in search check box or radio

        public ColorType Color { get; set; }//this will be used as a tag used in search check box

        //ingredients 

        public double Salt { get; set; }


        public double SodaAsh { get; set; }


        public double Water { get; set; }


        public double Dye { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }

    }
}
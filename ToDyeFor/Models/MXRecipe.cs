using System;

namespace ToDyeFor.Models
{
	[BsonIgnoreExtraElements]
    //^ that tells the program to just ignore any properties that aren't identified 
    public class MXRecipe
    {
        [BsonId]
        public ObjectId Id { get; set; }

        //user input
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("depth-of-shade")]
        public string ShadeDepth { get; set; }

        [BsonElement("weight-of-fabric")]
        public double FabricWeight { get; set; }

        [BsonElement("dye")]
        public  Dye { get; set; }

        //ingredients
        [BsonElement("salt")]
        public string Salt { get; set; }

        [BsonElement("sodaAsh")]
        public string SodaAsh { get; set; }

        [BsonElement("water")]
        public double Water { get; set; }

        [BsonElement("dye")]
        public  Dye { get; set; }

        ////This acts as a container for data that we are not using but it will take up processing data
        //[BsonExtraElements]
        //public object[] Bucket { get; set; }

    }
}
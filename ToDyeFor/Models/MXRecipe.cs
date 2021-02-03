using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ToDyeFor.Models
{
    [BsonIgnoreExtraElements]
    //^ that tells the program to just ignore any properties that aren't identified 
    public class MXRecipe
    {
        [BsonId]
        public ObjectId Id { get; set; }

        //How to use with MongoDB: http://www.binaryintellect.net/articles/6c715186-97b1-427a-9ccc-deb3ece7b839.aspx
        //to just get date only in code use:  DateTime.Now.Date
        [BsonElement("created-date")]
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime CreatedDate { get; set; }

        [BsonElement("updated-date")]
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime UpdatedDate { get; set; }

        //user input
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("depth-of-shade")]
        public double ShadeDepth { get; set; }

        [BsonElement("weight-of-fabric")]
        public double FabricWeight { get; set; }

        [BsonElement("dye-color")]
        public string DyeColor { get; set; }

        //ingredients
        [BsonElement("salt")]
        public double Salt { get; set; }

        [BsonElement("sodaAsh")]
        public double SodaAsh { get; set; }

        [BsonElement("water")]
        public double Water { get; set; }

        [BsonElement("dye")]
        public double Dye { get; set; }

        ////This acts as a container for data that we are not using but it will take up processing data
        //[BsonExtraElements]
        //public object[] Bucket { get; set; }

    }
}
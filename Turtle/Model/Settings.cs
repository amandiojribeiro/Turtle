using Newtonsoft.Json;
using System.Collections.Generic;
using Turtle.Model.Enums;

namespace Turtle.Model
{
    public class Settings
    {
        [JsonProperty(PropertyName = "mines")]
        public List<Coordinate> Mines { get; set; }

        [JsonProperty(PropertyName = "exit")]
        public Coordinate Exit { get; set; }

        [JsonProperty(PropertyName = "turtleStart")]
        public Coordinate TurtleStart { get; set; }

        [JsonProperty(PropertyName = "boardSizeY")]
        public int BoardSizeY { get; set; }

        [JsonProperty(PropertyName = "boardSizeX")]
        public int BoardSizeX { get; set; }

        [JsonProperty(PropertyName = "moves")]
        public List<string> Moves { get; set; }

        [JsonProperty(PropertyName = "initialDirection")]
        public Direction InitialDirection { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Spotify.Domain.SpecialModels
{
    public class RecommendationModel
    {
        public int Id { get; set; }
        public int Weight { get; set; }

        public RecommendationModel(int id, int weight)
        {
            Weight = weight;
            Id = id;
        }

    }
}

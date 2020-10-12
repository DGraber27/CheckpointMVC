﻿using CheckPoint.Data;
using CheckPoint.Models.PlatformModel;
using CheckPoint.Models.ReviewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Models.GameModels
{
    public enum ESRB { eC, E, E10, T, M, AO, RP, KA }
    public class GameListItem
    {
        [Display(Name = "Game ID")]
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Platform ID")]
        public int PlatformID { get; set; }
        [Display(Name = "Platform")]
        public string PlatTitle { get; set; }
        public string Developer { get; set; }
        [Display(Name = "Maturity Rating")]
        public ESRB ESRB { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Game Image")]
        public byte[] GameImage { get; set; }
        [Display(Name = "Average User Score")]
        public double AverageStarRating
        {
            get
            {
                double totalAverageRating = 0;

                foreach (var starRating in AllGameReviews)
                {
                    totalAverageRating += starRating.StarRating;
                }

                return (AllGameReviews.Count > 0) ? Math.Round(totalAverageRating / AllGameReviews.Count) : 0;
            }
        }
        public virtual List<ReviewListItem> AllGameReviews { get; set; }

        //public List<GameImageListItems> AllGameImages { get; set; }
        //public List<PlatformDetail> AllPlatforms {get; set;}

    }
}

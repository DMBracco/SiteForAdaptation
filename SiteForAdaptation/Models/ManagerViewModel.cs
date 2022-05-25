using System.Collections.Generic;

namespace SiteForAdaptation.Models
{
    public class ManagerViewModel
    {
        public int companyId { get; set; }
        public string companyName { get; set; }
        /// <summary>
        /// NavBars
        /// </summary>
        public string NavBarTitle_1 { get; set; }
        public string NavBarLink_1 { get; set; }

        public string NavBarTitle_2 { get; set; }
        public string NavBarLink_2 { get; set; }

        public string NavBarTitle_3 { get; set; }
        public string NavBarLink_3 { get; set; }

        public string NavBarTitle_4 { get; set; }
        public string NavBarLink_4 { get; set; }

        public string NavBarTitle_5 { get; set; }
        public string NavBarLink_5 { get; set; }

        /// <summary>
        /// Openings
        /// </summary>
        public string openingImagePath { get; set; }
        public string openingVideoPath { get; set; }
        public string openingFilePath { get; set; }
        /// <summary>
        /// StoryMaps
        /// </summary>
        public string storyMapsName_1 { get; set; }
        public string storyMapsNumber_1 { get; set; }
        public string storyMapsTittle_1 { get; set; }
        public string storyMapsSubtitle_1_1 { get; set; }
        public string storyMapsSubtitle_2_1 { get; set; }
        public string storyMapsVideoPath_1 { get; set; }
        public string storyMapsFilePath_1 { get; set; }

        public string storyMapsName_2 { get; set; }
        public string storyMapsNumber_2 { get; set; }
        public string storyMapsTittle_2 { get; set; }
        public string storyMapsSubtitle_1_2 { get; set; }
        public string storyMapsSubtitle_2_2 { get; set; }
        public string storyMapsVideoPath_2 { get; set; }
        public string storyMapsFilePath_2 { get; set; }

        public string storyMapsName_3 { get; set; }
        public string storyMapsNumber_3 { get; set; }
        public string storyMapsTittle_3 { get; set; }
        public string storyMapsSubtitle_1_3 { get; set; }
        public string storyMapsSubtitle_2_3 { get; set; }
        public string storyMapsVideoPath_3 { get; set; }
        public string storyMapsFilePath_3 { get; set; }

        public string storyMapsName_4 { get; set; }
        public string storyMapsNumber_4 { get; set; }
        public string storyMapsTittle_4 { get; set; }
        public string storyMapsSubtitle_1_4 { get; set; }
        public string storyMapsSubtitle_2_4 { get; set; }
        public string storyMapsVideoPath_4 { get; set; }
        public string storyMapsFilePath_4 { get; set; }

        public string storyMapsName_5 { get; set; }
        public string storyMapsNumber_5 { get; set; }
        public string storyMapsTittle_5 { get; set; }
        public string storyMapsSubtitle_1_5 { get; set; }
        public string storyMapsSubtitle_2_5 { get; set; }
        public string storyMapsVideoPath_5 { get; set; }
        public string storyMapsFilePath_5 { get; set; }

        public string storyMapsName_6 { get; set; }
        public string storyMapsNumber_6 { get; set; }
        public string storyMapsTittle_6 { get; set; }
        public string storyMapsSubtitle_1_6 { get; set; }
        public string storyMapsSubtitle_2_6 { get; set; }
        public string storyMapsVideoPath_6 { get; set; }
        public string storyMapsFilePath_6 { get; set; }

        public string storyMapsName_7 { get; set; }
        public string storyMapsNumber_7 { get; set; }
        public string storyMapsTittle_7 { get; set; }
        public string storyMapsSubtitle_1_7 { get; set; }
        public string storyMapsSubtitle_2_7 { get; set; }
        public string storyMapsVideoPath_7 { get; set; }
        public string storyMapsFilePath_7 { get; set; }

        public string storyMapsName_8 { get; set; }
        public string storyMapsNumber_8 { get; set; }
        public string storyMapsTittle_8 { get; set; }
        public string storyMapsSubtitle_1_8 { get; set; }
        public string storyMapsSubtitle_2_8 { get; set; }
        public string storyMapsVideoPath_8 { get; set; }
        public string storyMapsFilePath_8 { get; set; }

        public string storyMapsName_9 { get; set; }
        public string storyMapsNumber_9 { get; set; }
        public string storyMapsTittle_9 { get; set; }
        public string storyMapsSubtitle_1_9 { get; set; }
        public string storyMapsSubtitle_2_9 { get; set; }
        public string storyMapsVideoPath_9 { get; set; }
        public string storyMapsFilePath_9 { get; set; }

        public string storyMapsName_10 { get; set; }
        public string storyMapsNumber_10 { get; set; }
        public string storyMapsTittle_10 { get; set; }
        public string storyMapsSubtitle_1_10 { get; set; }
        public string storyMapsSubtitle_2_10 { get; set; }
        public string storyMapsVideoPath_10 { get; set; }
        public string storyMapsFilePath_10 { get; set; }

        /// <summary>
        /// UserTask
        /// </summary>
        public string userTaskTittle { get; set; }
        public string userTaskSubtittle { get; set; }
        public string userTaskText { get; set; }
        public string userTaskFilePath { get; set; }

        public List<UserTaskItemViewModel> userTaskItems { get; set; } = new List<UserTaskItemViewModel>();

        /// <summary>
        /// MemoForManager
        /// </summary>
        public string Tittle_1 { get; set; }
        public string Subtittle_1 { get; set; }

        public string Tittle_2 { get; set; }
        public string Subtittle_2 { get; set; }

        public string Tittle_3 { get; set; }
        public string Subtittle_3 { get; set; }

        public string Tittle_4 { get; set; }
        public string Subtittle_4 { get; set; }

        public string Tittle_5 { get; set; }
        public string Subtittle_5 { get; set; }

        /// <summary>
        /// Contact
        /// </summary>
        public string contactFileName { get; set; }
        public string contactFilePath { get; set; }

        public List<ContactItemViewModel> contactItems { get; set; } = new List<ContactItemViewModel>();
    }
}

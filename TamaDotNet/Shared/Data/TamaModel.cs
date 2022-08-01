using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamaDotNet.Shared.Data {
    public class TamaModel {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public string Name { get; set; }
        public int Hunger { get; set; }
        public DateTime lastFed { get; set; }
        public int Mood { get; set; }
        public DateTime lastMood { get; set; }

        public int Hygiene { get; set; }
        public DateTime LastShower { get; set; }
        public string ImgUrl { get; set; }
    }
}

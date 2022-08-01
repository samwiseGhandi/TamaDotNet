using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamaDotNet.Shared.Data {
    public class UserModel {
        public int Id { get; set; }
        public TamaModel Tama { get; set; }
        public int TamaId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamServices.Models;

namespace TeamServices.VO
{
    public class TeamVO
    {
        public string Name { get; set; }
        public ICollection<MemberVO> Members { get; set; }
    }
}

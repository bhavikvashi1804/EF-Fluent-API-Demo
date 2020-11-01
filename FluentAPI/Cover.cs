using DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    class Cover
    {
        public int Id { get; set; }

        //Annotation Property
        public Course Course { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Classes
{
    [Serializable]
    public class Project
    {
        public string Name { get; private set; }

        public Project(string Name)
        {
            this.Name = Name;
        }
        public override bool Equals(Object obj)
        {
            if (obj is Project)
            {
                if (this.Name == (obj as Project).Name)
                    return true;
                else
                    return false;
            }
            else
                return base.Equals(obj);
            
        }

    }

   
}

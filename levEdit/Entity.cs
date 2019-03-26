using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace levEdit
{
    public enum EntityType
    {
        Empty,
        Wall,
        Door,
        Terminal,
        PlayerSpawn,
        MonsterSpawn,
        ExitSpawn
    }
    public class Entity
    {

        [NotifyParentProperty(true)]
        public EntityType Type { get; set;}

        [NotifyParentProperty(true)]
        public string Id { get; set; }

        [NotifyParentProperty(true)]
        public int Hp { get; set; }


        public override string ToString()
        {
            switch (Type)
            {
                case EntityType.Door:
                    return "D";
                case EntityType.Wall:
                    return "W";
                case EntityType.Terminal:
                    return "T";
                case EntityType.MonsterSpawn:
                    return "M";
                case EntityType.PlayerSpawn:
                    return "P";
                case EntityType.ExitSpawn:
                    return "E";
                case EntityType.Empty:
                    return "";
                default:
                    return "?";
            }
        }
    }
}

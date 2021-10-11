using System;
using System.Collections.Generic;
using System.Text;

namespace MegaDesk_Schutz
{
    public enum DesktopMaterial
    {
        Laminate,
        Oak,
        Rosewood,
        Veneer,
        Pine
    }
    public class Desk
    {
        public int width { get; set; }
        public int depth { get; set; }
        public int drawers { get; set; }
        public DesktopMaterial material { get; set; }

        public Desk() { }
        public Desk(int xwidth, int xdepth, int xdrawers, DesktopMaterial xmaterial)
        {
            width = xwidth;
            depth = xdepth;
            drawers = xdrawers;
            material = xmaterial;
        }

        
    }
}

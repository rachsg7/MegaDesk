using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;


namespace MegaDesk_Schutz
{
    public class DeskQuote
    {
        public Desk customerDesk { get; set;  }

        public String customerName { get; set;  }
        public int area { get; set; }
        public int areaCost { get; set; }
        public int rushDays { get; set; }
        public int drawers { get; set; }
        public int drawerCost { get; set; }
        public int materialCost { get; set; }
        public int rushOrderCost { get; set; }
        public int totalCost { get; set; }
        public DateTime quoteDate { get; set; }

        public DeskQuote() { }
        public DeskQuote(Desk newCustomerDesk, String name, int newRushDays)
        {
            customerDesk = newCustomerDesk;
            customerName = name;
            area = newCustomerDesk.width * newCustomerDesk.depth;
            drawers = newCustomerDesk.drawers;
            quoteDate = DateTime.Now;
            rushDays = newRushDays;
            
        }
        public void CalculateQuote()
        {
            // Calculate areaCost
            areaCost = 200;
            
            if (area > 1000)
            {
                areaCost += area - 1000;
            }
            else
            {
                areaCost = 200;
            }
            // Calculate drawerCost
            drawerCost = drawers * 50;

            // Calculate materialCost
            materialCost = getMaterialPrice(customerDesk.material);

            // Calculate rushOrderCost
            rushOrderCost = getRushOrderPrice(rushDays);

            totalCost = areaCost + drawerCost + materialCost + rushOrderCost;
        }

        public int getMaterialPrice(DesktopMaterial m)
        {
            switch (m)
            {
                case DesktopMaterial.Laminate:
                    return 100;

                case DesktopMaterial.Oak:
                    return 200;

                case DesktopMaterial.Rosewood:
                    return 300;

                case DesktopMaterial.Veneer:
                    return 125;

                case DesktopMaterial.Pine:
                    return 50;

                default:
                    return 0;

            }
        }

        public const string RUSHORDERPRICES = @"rushOrderPrices.txt";

        public static int[] GetPrices()
        {
            string[] lines = File.ReadAllLines(RUSHORDERPRICES);

            int[] rushOrderPrices = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                rushOrderPrices[i] = Int32.Parse(lines[i]);
            }
            return rushOrderPrices;
        }

        public int getRushOrderPrice(int rushOrder)
        {
            switch (rushOrder)
            {
                case 0:
                    return 0;

                case 1:
                    if (area < 1000)
                    {
                        return GetPrices()[0];
                    }
                    else if (area >= 1000 && area <= 2000)
                    {
                        return GetPrices()[1];
                    }
                    else if (area > 2000)
                    {
                        return GetPrices()[2];
                    }
                    break;
                case 2:
                    if (area < 1000)
                    {
                        return GetPrices()[3];
                    }
                    else if (area >= 1000 && area <= 2000)
                    {
                        return GetPrices()[4];
                    }
                    else if (area > 2000)
                    {
                        return GetPrices()[5];
                    }
                    break;
                case 3:
                    if (area < 1000)
                    {
                        return GetPrices()[6];
                    }
                    else if (area >= 1000 && area <= 2000)
                    {
                        return GetPrices()[7];
                    }
                    else if (area > 2000)
                    {
                        return GetPrices()[8];
                    }
                    break;
                default:
                    break;
            }
            return 0;
        }


    }
}

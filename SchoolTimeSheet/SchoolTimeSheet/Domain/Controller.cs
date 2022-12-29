using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeSheet.Domain
{
    internal class Controller
    {
        private static Controller instance;
        public static Controller Instance 
        { 
            get 
            {
                if (instance == null)
                    instance = new Controller();
                return instance;
            }
        }

        public Program Program { get; private set; }

        public Controller() 
        {
            Program = new Program("Baccalauréat en informatique", "BAC-IFT");

            Mock();
        }

        public Session GetSession(int year, Season season)
        {
            return Program.GetSession(year, season);
        }

        private void Mock()
        {
            var automne2022 = new Session(2022, Season.Fall);
            automne2022.AddClass(new Class("Algorithmes et structures de données", "GLO-2100", 3));
            automne2022.AddClass(new Class("Réseaux", "GLO-2000", 3));
            automne2022.AddClass(new Class("Génie logiciel orienté objet", "GLO-2004", 3));
            automne2022.AddClass(new Class("Mathématiques pour informaticien", "MAT-1919", 3));
            automne2022.AddClass(new Class("Introduction aux statistiques", "STT-1000", 3));
            automne2022.AddClass(new Class("Pratique de l'informatique", "IFT-1111", 0));
            var hiver2023 = new Session(2023, Season.Winter);
            hiver2023.AddClass(new Class("Conception et analyse d'algorithmes", "IFT-3001", 3));
            hiver2023.AddClass(new Class("Informatique théorique", "IFT-2002", 3));
            hiver2023.AddClass(new Class("Logique et technique de preuves", "IFT-1000", 3));
            hiver2023.AddClass(new Class("Systèmes d'exploitation", "GLO-2001", 3));
            hiver2023.AddClass(new Class("Introduction aux processus du génie logiciel", "GLO-2003", 3));

            Program.AddSession(automne2022);
            Program.AddSession(hiver2023);
        }
    }
}

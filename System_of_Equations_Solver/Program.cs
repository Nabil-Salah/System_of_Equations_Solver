using System;
using System.Collections.Generic;

namespace System_of_Equations_Solver
{
    public abstract class SolveSystem
    {
        protected enum State{ ONESOLUTION,INFINTYSOLUTION,NOSOLUTION};
        protected List<List<int>> augmantedMatrix;
        SolveSystem()
        {
            this.augmantedMatrix = new List<List<int>>();
        }
        public SolveSystem(List<List<int>> augmantedMatrix)
        {
            this.augmantedMatrix = augmantedMatrix;
        }
        protected State checkSolve()
        {
            return State.ONESOLUTION;
        }
        protected void interChanege(int column,int row)//makeCurrentLead
        {

        }
        protected void scalling(int column,int row)//makeLeadOne
        {

        }
        protected void replacement(int column, int row)
        {

        }
        public abstract void echelonForm();
    }
    public class GaussianElimination : SolveSystem
    {
        GaussianElimination(List<List<int>> augmantedMatrix): base(augmantedMatrix)
        {

        }
        public override void echelonForm()
        {

        }

    }
    public class GaussJordonElimination : SolveSystem
    {
        GaussJordonElimination(List<List<int>> augmantedMatrix) : base(augmantedMatrix)
        {

        }
        private void gaussJordonExtension()
        {

        }
        public override void echelonForm()
        {

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's Start Work!");
        }
    }
}
//nabil: Put Prototypes - EchelonForm
//Mostafa: CheckSolve - Make Leading Be one
//Gohary:Make Current Lead - Input
//Alaa:Replacement - Gauss Extension
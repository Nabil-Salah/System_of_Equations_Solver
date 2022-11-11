using System;
using System.Collections.Generic;

namespace System_of_Equations_Solver
{
    public abstract class SolveSystem
    {
        protected enum State { ONESOLUTION, INFINTYSOLUTION, NOSOLUTION };
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
            int num_columns = augmantedMatrix[0].Count;
            int num_rows = augmantedMatrix.Count;
            int nonzerocnt = 0;
            for (int i = num_columns - 1; i >= 0; --i)
            {
                if (augmantedMatrix[num_rows - 1][i] != 0)
                {
                    ++nonzerocnt;
                }
            }
            if (nonzerocnt == 0)
            {
                return State.INFINTYSOLUTION;
            }
            else if ((nonzerocnt == 1) && (augmantedMatrix[num_rows - 1][num_columns - 1] != 0))
            {
                return State.NOSOLUTION;
            }
            else if ((nonzerocnt == 1) && (augmantedMatrix[num_rows - 1][num_columns - 1] == 0))
            {
                return State.ONESOLUTION;
            }
            else if ((nonzerocnt == 2) && (augmantedMatrix[num_rows - 1][num_columns - 1] != 0))
            {
                return State.ONESOLUTION;
            }
            else
            {
                return State.NOSOLUTION;
            }
        }
        protected void interChanege(int column, int row)//makeCurrentLead
        {

        }
        protected void scalling(int column, int row)//makeLeadOne
        {

        }
        protected void replacement(int column, int row)//make all beneath lead equal 1
        {
            for (int r = row+1; r < row; r++)
            { // for each row ...
                /* calculate divisor and multiplier */
                int d = augmantedMatrix[row][column];
                if (d == 0) continue;
                int m = augmantedMatrix[r][column] / d;

                for (int c = 0; c < column; c++)
                { // for each column ...
                    augmantedMatrix[r][c] -= augmantedMatrix[r][c] * m;  // make other = 0
                }
            }
        }
        public abstract void echelonForm();
    }
    public class GaussianElimination : SolveSystem
    {
        GaussianElimination(List<List<int>> augmantedMatrix) : base(augmantedMatrix)
        {

        }
        public override void echelonForm()
        {
            for (int i = 0; i < augmantedMatrix.Count; i++)
            {
                interChanege(i, i);
                scalling(i, i);
                replacement(i, i);
            }
        }

    }
    public class GaussJordonElimination : SolveSystem
    {
        GaussJordonElimination(List<List<int>> augmantedMatrix) : base(augmantedMatrix)
        {

        }
        private void gaussJordonExtension(int column, int row)
        {
            for (int r = row - 1; r >= 0; r--)
            { // for each row ...
                /* calculate divisor and multiplier */
                int d = augmantedMatrix[row][column];
                if (d == 0) continue;
                int m = augmantedMatrix[r][column] / d;

                for (int c = 0; c < column; c++)
                { // for each column ...
                    augmantedMatrix[r][c] -= augmantedMatrix[r][c] * m;  // make other = 0
                }
            }
        }
        public override void echelonForm()
        {
            for (int i = 0; i < augmantedMatrix.Count; i++)
            {
                interChanege(i, i);
                scalling(i, i);
                replacement(i, i);
                gaussJordonExtension(i, i);
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// checked before of all column zero
            /// checcked for valisdity
            /// </summary>
            Console.WriteLine("Let's Start Work!");
        }
    }
}
//nabil: Put Prototypes - EchelonForm
//Mostafa: CheckSolve - Make Leading Be one
//Gohary:Make Current Lead - Input
//Alaa:Replacement - Gauss Extension
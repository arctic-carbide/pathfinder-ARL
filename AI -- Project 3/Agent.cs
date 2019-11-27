using System;
using System.Collections.Generic;
using System.Text;

namespace AI____Project_3
{
    class Agent
    {
        AreaMap map = new AreaMap();
        private Tile CurrentTile { get; set; }
        private const double RandomPolicyChance = 0.05;
        private const double OptimalPolicyChance = 1.0 - RandomPolicyChance;
        private const double OnTargetTrajectoryChance = 0.8;
        private const double DeviationChance = (1 - OnTargetTrajectoryChance) / 2.0;

        public void Start(int trialsToRun)
        {
            for (int trialNumber = 1; trialNumber <= trialsToRun; trialNumber++)
            {
                RunTrial();
            }
        }

        private void RunTrial()
        {
            StartWithRandomTile();
            FindTheGoal();
        }
        private void StartWithRandomTile()
        {
            do
            {
                CurrentTile = map.SelectRandomTile();
            } while (!(CurrentTile is FloorTile));

        }
        private void FindTheGoal()
        {
            bool goalFound = false;

            // goal: get to the goal
            // for your current tile, 

            do
            {
                if (CurrentTile is GoalTile) goalFound = true;
                else
                {
                    CurrentTile = NavigateToNewTile();
                }
            }
            while (!goalFound);

        }

        private Tile NavigateToNewTile()
        {
            Tile newTile = null;
            Policy action;

            action = DetermineAction();

            return newTile;
        }

        private Policy DetermineAction()
        {
            Policy p;
            Random r = new Random();

            if (r.NextDouble() > RandomPolicyChance)
            {
                p = map.GetOptimalPolicy(CurrentTile);
            }
            else
            {
                p = map.GetRandomPolicy(CurrentTile);
            }

            return p;
        }

    }
}

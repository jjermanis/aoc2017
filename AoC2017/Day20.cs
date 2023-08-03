using System.Text.RegularExpressions;

namespace AoC2017;

public class Day20 : DayBase, IDay
{
    internal class Particle
    {
        public long[] Pos;
        public long[] Velo;
        public long[] Accel;

        public Particle(int[] vals)
        {
            Pos = new long[3];
            Velo = new long[3];
            Accel = new long[3];
            for (int i = 0; i < 3; i++)
            {
                Pos[i] = vals[i];
                Velo[i] = vals[i+3];
                Accel[i] = vals[i+6];
            }
        }

        public Particle(Particle orig)
        {
            Pos = (long[])orig.Pos.Clone();
            Velo = (long[])orig.Velo.Clone();
            Accel = (long[])orig.Accel.Clone();
        }

        public string PosKey()
            => $"{Pos[0]},{Pos[1]}, {Pos[2]}";

        public long TotalAcceleration()
            => Math.Abs(Accel[0]) + Math.Abs(Accel[1]) + Math.Abs(Accel[2]);

        public void Move()
        {
            for (int i = 0; i < 3; i++)
            {
                Velo[i] += Accel[i];
                Pos[i] += Velo[i];
            }
        }
    }

    private readonly List<Particle> _particles;

    public Day20(string filename)
    {
        var lines = TextFileLines(filename);
        _particles = new List<Particle>();
        foreach (var line in lines)
        {
            var m = Regex.Match(line,
                @"p=<(-?\d*),(-?\d*),(-?\d*)>, v=<(-?\d*),(-?\d*),(-?\d*)>, a=<(-?\d*),(-?\d*),(-?\d*)>");
            var vals = new int[9];
            for (int x = 0; x < 9; x++)
                vals[x] = int.Parse(m.Groups[x+1].Value);
            _particles.Add(new Particle(vals));
        }
    }
        

    public Day20() : this("Day20.txt")
    {
    }

    public void Do()
    {
        Console.WriteLine($"{nameof(ParticleStayingClosestToOrigin)}: {ParticleStayingClosestToOrigin()}");
        Console.WriteLine($"{nameof(ParticleCountAfterCollisions)}: {ParticleCountAfterCollisions()}");
    }

    /// <summary>
    /// Day 20, Part 1
    /// </summary>
    /// <returns>The ID of the particle that will stay closed to the origin.</returns>    
    public int ParticleStayingClosestToOrigin()
    {
        // Note: this algo only works on cases with the smallest speed vectors
        // (one 1, two 0's). I believe it is likely everyone's data will have this.
        var bestNetAccel = long.MaxValue;
        var result = -1;
        for (int i=0; i < _particles.Count; i++)
        {
            var curr = _particles[i];
            if (curr.TotalAcceleration() == 1)
            {
                for (var j = 0; j < 3; j++)
                    if (curr.Accel[j] !=0)
                    {
                        var currNetAccel = curr.Velo[j] / curr.Accel[j];
                        if (currNetAccel < bestNetAccel)
                        {
                            result = i;
                            bestNetAccel = currNetAccel;
                        }
                    }
            }
        }
        return result;
    }

    /// <summary>
    /// Day 20, Part 2
    /// </summary>
    /// <returns>Number of remaining particles after all collisions.</returns>    
    public int ParticleCountAfterCollisions()
    {
        var remainingParticles = CopyParticleList(_particles);
        var currTurn = 0;
        var recentCollisionTurn = 0; 
        while (true)
        {
            foreach (var particle in remainingParticles)
                particle.Move();

            var currPositions = new Dictionary<string, int>();
            foreach (var particle in remainingParticles)
            {
                if (!currPositions.ContainsKey(particle.PosKey()))
                    currPositions[particle.PosKey()] = 1;
                else
                    currPositions[particle.PosKey()]++;
            }

            var updateParticles = new List<Particle>();
            foreach (var particle in remainingParticles)
                if (currPositions[particle.PosKey()] == 1)
                    updateParticles.Add(particle);

            if (remainingParticles.Count != updateParticles.Count)
                recentCollisionTurn = currTurn;

            remainingParticles = updateParticles;
            if (remainingParticles.Count <= 1 ||
                currTurn - recentCollisionTurn >= 50)
                return remainingParticles.Count;

            currTurn++;
        }
    }

    private List<Particle> CopyParticleList(List<Particle> orig)
    {
        var result = new List<Particle>();
        foreach (var particle in orig)
            result.Add(new Particle(particle));
        return result;
    }
}
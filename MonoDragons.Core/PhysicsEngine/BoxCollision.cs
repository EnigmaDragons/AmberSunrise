using System;
using System.Collections.Generic;
using System.Linq;
using MonoDragons.Core.Common;
using MonoDragons.Core.Entities;

namespace MonoDragons.Core.PhysicsEngine
{
    public sealed class BoxCollision : ISystem
    {
        public void Update(IEntities entities, TimeSpan delta)
        {
            var moving = GetMoving(entities);
            if (!moving.Any())
                return;
            entities.ForEach(
                e => e.With<BoxCollider>(
                    collider => moving.ForEach(x => StopIfWouldCollide(x, collider, delta))));
        }

        private List<GameObject> GetMoving(IEntities entities)
        {
            var result = new List<GameObject>();
            entities.ForEach(
                e => e.With<Motion2>(
                    motion => motion.If(motion.Velocity.Speed > 0,
                        () => result.Add(e))));
            return result;
        }

        private void StopIfWouldCollide(GameObject o1, BoxCollider o2, TimeSpan time)
        {
            if(o2.IsBlocking && o2.Transform.Intersects(GetProposedMotion(o1, time)))
                o1.Get<Motion2>().Velocity.Speed = 0;
        }

        private Transform2 GetProposedMotion(GameObject o, TimeSpan time)
        {
            return o.Get<Spatial2>().Transform + o.Get<Motion2>().Velocity.GetDelta(time);
        }
    }
}

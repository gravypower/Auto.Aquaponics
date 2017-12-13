using System;
using Ponics.AquaponicSystems;
using Ponics.Components;
using Ponics.HardCodedData.Organisms;

namespace Ponics.HardCodedData.AquaponicSystems
{
    public class AaronsAquaponicSystem: AquaponicSystem
    {
        public AaronsAquaponicSystem()
        {
            Id = Guid.Parse("47236a2e40f047a2923034c610c5e444");
            Name = "Aaron's Aquaponics System";

            var nitrosomonas = new Nitrosomonas();
            var nitrospira = new Nitrospira();

            var fishTank = new Component
            {
                Id = Guid.Parse("77eb39a3-00fe-4cf7-b422-37c1408bfbd6"),
                Name = "fishTank"
            };

            fishTank.AddOrganisms(new SilverPerch().Id, nitrosomonas.Id, nitrospira.Id);
            Components.Add(fishTank);

            var growBed = new Component
            {
                Id = Guid.Parse("02067a53-cdad-4ccb-9f04-3cab69b10008"),
                Name = "growBed"
            };
            growBed.AddOrganisms(new Worm().Id, nitrosomonas.Id, nitrospira.Id);
            Components.Add(growBed);

            var sumpTank = new Component
            {
                Id = Guid.Parse("a0e67c51-fc19-4ffc-a39e-167e3711f68b"),
                Name = "sumpTank"
            };
            sumpTank.AddOrganisms(new GoldFish().Id, nitrosomonas.Id, nitrospira.Id);
            Components.Add(sumpTank);

            ComponentConnections.Add( new ComponentConnection
            {
                SourceId = fishTank.Id,
                TargetId = growBed.Id
            });

            ComponentConnections.Add(new ComponentConnection
            {
                SourceId = growBed.Id,
                TargetId = sumpTank.Id
            });

            ComponentConnections.Add(new ComponentConnection
            {
                SourceId = sumpTank.Id,
                TargetId = fishTank.Id
            });
        }
    }
}

using UnityEngine;

public class Bubbles : MonoBehaviour
{
        public ParticleSystem Particle;
        public ParticleSystem Particles;

        private void FixedUpdate()
        {
                if (Particles.particleCount < 600 && Particles.particleCount > 0)
                {
                        Particle.Play();
                }
        }
}

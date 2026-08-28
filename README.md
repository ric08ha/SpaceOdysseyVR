# Space Odyssey VR

A Unity-based VR space exploration experience that lets users travel between planets, walk their surfaces, and *feel* how gravity and atmosphere actually differ across the solar system. Built as an immersive learning experience as much as an exploration game, alongside a fully functional spacecraft cockpit.

## Overview

Space Odyssey lets players pilot a spacecraft, travel between planetary destinations, and walk around each planet's surface in immersive VR. Built using Unity's XR Interaction Toolkit.

Beyond exploration, the project is designed as a **learning experience**, giving users an intuitive, physical sense of how gravity and atmosphere differ across the solar system, something that's hard to grasp from textbooks alone. By tuning locomotion physics per celestial body, Space Odyssey lets users *feel* the difference between a bounding, low-gravity Moon walk and the crushing, near-Earth-weight pull of Saturn's upper atmosphere.

## Features

- 🌌 **Planet Travel System** — Seamless transitions between Mars, Moon, Saturn, and Mercury
- 🧑‍🚀 **Astronaut Locomotion** — Walkable movement on planetary surfaces
- 🛰️ **Zero-Gravity Movement** — Physics-based locomotion for space environments
- 🪐 **Planet-Specific Gravity Simulation** — Locomotion physics scaled to approximate real-world gravity for each destination, so movement, jump height, and fall speed genuinely differ planet to planet
- 🌫️ **Atmospheric Variation** — Visual and environmental cues (sky tone, haze, lighting) reflecting each body's atmospheric conditions
- 🚀 **Interactive Cockpit** — Functional cockpit shutter and spacecraft interactions
- ✋ **XR Hand Tracking** — Natural hand-based interaction using Unity's XR Hands package
- 🪐 **Multiple Planetary Environments** — Explorable terrain across four distinct planets

## Gravity & Atmosphere Reference

Locomotion on each body is tuned relative to real-world reference values, so the experience is educational as well as immersive:

| Body | Surface Gravity | Relative to Earth | Atmosphere |
|------|-----------------|--------------------|------------|
| **Moon** | 1.62 m/s² | ~0.16g | None (vacuum) — expect exaggerated, bounding jumps |
| **Mars** | 3.71 m/s² | ~0.38g | Thin CO₂ atmosphere — lighter movement, hazy reddish sky |
| **Mercury** | 3.7 m/s² | ~0.38g | Virtually none — stark lighting, sharp shadows, no diffusion |
| **Saturn** *(upper atmosphere)* | 10.44 m/s² | ~1.06g | Thick hydrogen/helium atmosphere — no solid surface; near-Earth weight with dense, turbulent skies |

*Note: values are approximate real-world references used to guide locomotion tuning (jump height, fall speed, movement drag) — not a full physics simulation.*

## Built With

- Unity (XR Interaction Toolkit, XR Hands)
- Blender (3D modeling)
- Git LFS (for large binary assets — models, terrain files)

## Team Contributions

| Member | Contribution |
|--------|-------------|
| **Kritika** | Unity scripting, physics, animations, interactions, planet travel/transition system|
| **Emlin** | 3D modeling and asset sourcing (Blender), Unity animation work, game flow collaboration |
| **Richa** | 3D modeling (Blender) and terrain asset sourcing, Planet terrain functionality (Unity)|

## Getting Started

### Prerequisites
- Unity Hub with the project's Unity Editor version installed (check `ProjectSettings/ProjectVersion.txt`)
- [Git LFS](https://git-lfs.github.com/) installed (required — this repo uses LFS for large model/terrain files)

### Setup
\`\`\`bash
git clone https://github.com/skritika563/OdysseyVR.git
cd OdysseyVR
git lfs pull
\`\`\`
Then open the project folder in Unity Hub.

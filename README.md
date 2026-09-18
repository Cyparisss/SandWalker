[project_readme_technical_documentation.md](https://github.com/user-attachments/files/32386396/project_readme_technical_documentation.md)
# Project README & Technical Documentation

---

## 1. Project Overview & Deliverables

This repository contains the complete Unreal Engine project and source files for a playable prototype sandbox. The prototype features interactive physics manipulation (grabbing and launching objects), dynamic camera zoom controls, and an environment-aware ledge-grabbing traversal mechanic.

### Summary of Deliverables
- **Unreal Project**: Complete, functional project containing all source files required for evaluation.
- **Playable Prototype**: Testable sandbox map featuring all implemented character and physics mechanics.
- **Technical Documentation**: Comprehensive overview of project architecture, interaction design, physics systems, and technical decisions.
- **AI Statement of Intent**: Detailed disclosure of artificial intelligence tools utilized, scope of usage, benefits, and limitations encountered.

---

## 2. Technical Documentation

### 2.1 Overall Project Architecture

The architecture relies primarily on a centralized actor model centered around **`BP_ThirdPersonCharacter`**. This main Blueprint integrates player input, camera management components, physics handles, and trace-based environmental detection routines.

```
+-----------------------------------------------------------------------+
|                       BP_ThirdPersonCharacter                         |
+-----------------------------------------------------------------------+
|  - SpringArmComponent    --> Controls dynamic camera zoom bounds       |
|  - PhysicsHandleComp     --> Manages physics object grabbing/holding   |
|  - Ledge Tracing System  --> Handles wall/ledge detection & alignment  |
+-----------------------------------------------------------------------+
```

---

### 2.2 Main Classes, Blueprints & Components

* **`BP_ThirdPersonCharacter` (Blueprint Class)**  
  The core player actor responsible for handling locomotion, mapping input actions, managing character states (e.g., ground movement, falling, hanging), and processing raycast routines.
* **`SpringArmComponent` (Component)**  
  Attached to the character mesh to maintain camera offset and smoothing. Dynamically adjusts its target arm length based on player scroll input.
* **`PhysicsHandleComponent` (Component)**  
  Attached to the character root to manipulate 3D physics-enabled objects (e.g., interactive cubes) within the world.

---

### 2.3 Interaction Systems

#### A. Camera Zoom System
* **Input**: Mouse Wheel Up / Mouse Wheel Down.
* **Logic**:
  * Modifies the `TargetArmLength` property of the `SpringArmComponent`.
  * Decrements distance on **Mouse Wheel Up** and increments distance on **Mouse Wheel Down** in steps of **25 units**.
  * Math is clamped using a `Clamp (Float)` node between **300 and 500 units**, ensuring the player's view remains within optimal bounds.

#### B. Ledge Grabbing Mechanic
* **Execution Flow**:
  1. **State Condition**: Evaluates whether the character is actively in a **Falling** movement state.
  2. **Wall Detection**: Fires a forward line trace from the character vector to detect nearby vertical geometry.
  3. **Ledge Detection**: Upon hitting a wall, a secondary downward trace locates the top horizontal edge.
  4. **State Freeze**: Halts all linear movement immediately (`Stop Movement Immediately`) and transitions the character into a looping ledge-grab animation.
  5. **Transform Alignment**: Snaps and aligns the character's local offset to match the height and depth of the detected ledge while rotating the actor perpendicular to the wall normal vector.

---

### 2.4 Physics Systems Developed

#### Object Grabbing & Launching
* **Detection & Capture**:
  * Triggering the **Grab** input casts a **300-unit line trace** forward from the camera's perspective.
  * If the trace hits a physics-simulated object, the `PhysicsHandleComponent` grabs the target component at the impact location.
* **Holding Behavior**:
  * On `Event Tick`, the target location of the held object is recalculated continuously to hover **300 units** in front of the camera forward vector.
* **Release & Impulse Launching**:
  * Releasing the input detaches the object while maintaining its linear and angular velocity.
  * Rapid camera movement prior to release transfers momentum to the object, allowing players to sling or launch interactive cubes across the sandbox.

---

### 2.5 Main Technical Choices

* **Centralized Character Blueprint**: Chosen for simplified component communication during rapid prototyping of camera, movement, and physics interactions.
* **Dual-Trace Ledge Detection**: Replaces static volume placement with dynamic line tracing, ensuring scalable ledge interactions on arbitrary geometry without requiring custom collision setups.
* **Physics Handle Component**: Delivers physics manipulation while maintaining collision physics, avoiding issues where grabbed meshes clip into dynamic map geometry.

---

## 3. AI Statement of Intent

### 3.1 Overview
During the development of this project, **Gemini AI** was utilized as an assistive technology for troubleshooting logic, optimizing mathematical formulas, and brainstorming gameplay mechanics.

### 3.2 Breakdown of AI Usage

| Category | Details |
| :--- | :--- |
| **Tools Used** | Gemini AI (Google) |
| **Where AI Was Used** | Blueprint error diagnosing, trace vector math optimization, mechanic brainstorming, and concept referencing. |
| **Why AI Was Used** | To streamline bug fixing and explore standard implementation patterns for character-environment interactions. |
| **How AI Was Used** | Provided targeted prompts regarding line-trace setups, spring arm clamping logic, and velocity retention upon physics release. Suggestions were manually translated and tested inside Unreal Engine. |
| **Benefits Obtained** | Accelerated debugging cycles, clearer insight into Unreal trace logic, and inspiration for environmental traversal mechanics. |
| **Limitations Encountered** | AI guidance occasionally referenced node names or configurations incompatible with specific Unreal Engine context, requiring manual revision and logic adaptation. |

### 3.3 Verification & Compliance
All Blueprint logic, math nodes, and physics implementations assisted by AI were **reviewed, integrated, fully understood, tested, and verified** directly within the Unreal Engine project environment.

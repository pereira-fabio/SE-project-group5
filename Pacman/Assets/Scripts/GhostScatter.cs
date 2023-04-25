using UnityEngine;

public class GhostScatter : GhostBehaviour
{
    private void OnDisable(){
        this.ghost.chase.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other){
        Node node = other.GetComponent<Node>();

        if(node != null && this.enabled && !this.ghost.frightened.enabled){
            int index = Random.Range(0, node.availibleDirections.Count);

            if(node.availibleDirections[index] == -this.ghost.movement.direction && node.availibleDirections.Count > 1){
                    index++;

                    if(index >= node.availibleDirections.Count){
                        index = 0;
                    }
            }

            this.ghost.movement.SetDirection(node.availibleDirections[index]);
        }
    }
}

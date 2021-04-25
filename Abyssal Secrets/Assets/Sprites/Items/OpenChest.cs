using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenChest : MonoBehaviour
{
    private static List<Artifact> artifactPool = new List<Artifact>() {
        new Artifact("Six Tokens", "Little tokens seemingly made of various metals. Various animals are engraved on one side, but they all share someone’s head on the other… probably currency, possibly ammunition."), 
        new Artifact("One Waffleb Weapon", "A single pronged weapon, like a trident of sorts, small yet sturdy. Perhaps used to extract the entrails of enemies? The faded writing etched on the underside reads: waffleb"),
        new Artifact("Seven Gems","Seven small gems, all bearing a different shape except for a pair. The smallest is four sided, and the largest seems to have twenty. Etched with numerical values, this could have been used for divination. I wonder what fate has in store for me…"),
        new Artifact("Compass","A bizarre little watch with the letters N, E, S and W and a single needle that constantly moves around. A word was hand-written on the back, reading « R’lyeh »… is this… blood?"),
        new Artifact("« Selected Letters IV »","A square object with a hard, leathery shell holding leafy membranes. This could be what they called a book, the ancient database system. The cover reads « Selected Letter IV », and the writing inside is smeared, except for the title… Letter 617?"),
        new Artifact("A Stone Tablet","A stone tablet, green and slimy to the touch. The engravings are faded and read something unintelligible: Ph'nglui mglw'nafh Cthulhu R'lyeh wgah'nagl fhtagn. There’s that « R’lyeh » word again…")
    };
    private Artifact artifact;
    // Start is called before the first frame update
    void Start()
    {
        artifact = artifactPool[GetRandomIndex(artifactPool)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerArtifacts>().AddArtifact(artifact);
            gameObject.SetActive(false);
        }
    }

    private int GetRandomIndex(List<Artifact> pool)
    {
        System.Random rd = new System.Random();
        int rand_num = rd.Next(0, pool.Count-1);

        return rand_num;
    }
}

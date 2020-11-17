using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classroom.LuwiGeneralCode
{
    public class AudioListUtils : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip clickClip;
        public AudioClip dropCorrectClip;
        public AudioClip dropWrongClip;

        public List <AudioClip> audioClips;


        public void PlayClickClip()
        {
            audioSource.clip = clickClip;
            audioSource.Play();
        }

        public void PlayDropCorrectClip()
        {
            audioSource.clip = dropCorrectClip;
            audioSource.Play();
        }

        public void PlayDropWrongClip()
        {
            audioSource.clip = dropWrongClip;
            audioSource.Play();
        }
    }
}
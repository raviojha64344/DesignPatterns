using DesignPattern.MessagePattern.Attributes;
using DesignPattern.MessagePattern.Global;
using DesignPattern.MessagePattern.Messages;
using DesignPattern.MessagePattern.Messages.Interfaces;
using TMPro;
using UnityEngine;

namespace DesignPattern.MessagePattern.UI
{
    /*
     * Score UI
     */
    public class ScoreUI : GlobalBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreTxt;

        private void Start()
        {
            ScoreUpdateMessage
                .InstanceOf()
                .SetScore(1)
                .Send();
        }

        [MessageHandler(typeof(ScoreUpdateMessage))]
        public void UpdateScore(IMessage message)
        {
            var scoreUpdateMsg = message as ScoreUpdateMessage;
            if(scoreUpdateMsg != null)
            {
                UpdateUI(scoreUpdateMsg.Score);
            }
        }

        private void UpdateUI(float score)
        {
            if(scoreTxt != null)
            {
                Debug.LogFormat("Score {0}", score.ToString("00"));
                scoreTxt.text = string.Format("Score {0}",score.ToString("00"));
            }
        }
    }
}

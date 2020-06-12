using DesignPattern.MessagePattern.Attributes;
using DesignPattern.MessagePattern.Global;
using DesignPattern.MessagePattern.Messages;
using DesignPattern.MessagePattern.Messages.Interfaces;
using TMPro;
using UnityEngine;

namespace DesignPattern.MessagePattern.UI
{
    /*
     * Top Score UI
     */
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TopScoreUI : GlobalBehaviour
    {
        private TextMeshProUGUI scoreTxt;

        protected override void CollectComponent()
        {
            base.CollectComponent();
            scoreTxt = GetComponent<TextMeshProUGUI>();
        }

        private void UpdateUI(float score)
        {
            if(scoreTxt != null)
            {
                Debug.LogFormat("Score {0}", score.ToString("00"));
                scoreTxt.text = string.Format("Score {0}", score.ToString("00"));
            }
        }

        [MessageHandler(typeof(ScoreUpdateMessage))]
        public void UpdateScoreUI(IMessage message)
        {
            ScoreUpdateMessage scoreUpdateMsg = message as ScoreUpdateMessage;
            if (scoreUpdateMsg != null)
            {
                UpdateUI(scoreUpdateMsg.Score);
            }
        }
    }
}

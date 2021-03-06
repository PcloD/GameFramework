﻿//----------------------------------------------
// Flip Web Apps: Game Framework
// Copyright © 2016 Flip Web Apps / Mark Hewitt
//
// Please direct any bugs/comments/suggestions to http://www.flipwebapps.com
// 
// The copyright owner grants to the end user a non-exclusive, worldwide, and perpetual license to this Asset
// to integrate only as incorporated and embedded components of electronic games and interactive media and 
// distribute such electronic game and interactive media. End user may modify Assets. End user may otherwise 
// not reproduce, distribute, sublicense, rent, lease or lend the Assets. It is emphasized that the end 
// user shall not be entitled to distribute or transfer in any way (including, without, limitation by way of 
// sublicense) the Assets in any other way than as integrated components of electronic games and interactive media. 

// The above copyright notice and this permission notice must not be removed from any files.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//----------------------------------------------

using GameFramework.GameStructure.GameItems.Messages;
using UnityEngine;
using GameFramework.Helper;

namespace GameFramework.GameStructure.Game.ObjectModel.Abstract
{
    /// <summary>
    /// Class that holds information about a gameitem condition.
    /// </summary>
    [System.Serializable]
    public abstract class GameCondition : ScriptableObject, IScriptableObjectContainerSyncReferences
    {

        /// <summary>
        /// Perform any common initialisation for all Conditions before invoking Initialise
        /// </summary>
        /// <returns></returns>
        public void InitialiseCommon()
        {
            Initialise();
        }

        /// <summary>
        /// Override this method if you need to do any specific initialisation for the Conditions implementation.
        /// </summary>
        /// <returns></returns>
        protected virtual void Initialise() { }

        /// <summary>
        /// Returns messages types that should be listened to that might indicate this condition needs reevaluating.
        /// </summary>
        /// The base implementation returns UpdateMessage so that this will be evaluated every frame.
        /// <returns></returns>
        public virtual System.Type[] GetTriggerMessages()
        {
            return new[] { typeof(UpdateMessage) };
        }

        /// <summary>
        /// Perform all common things for the Condition before invoking EvaluateCondition
        /// </summary>
        /// <returns></returns>
        public bool EvaluateConditionCommon(MonoBehaviour monoBehaviour)
        {
            return EvaluateCondition(monoBehaviour);
        }

        /// <summary>
        /// Evaluate the current condition
        /// </summary>
        /// <returns></returns>
        public abstract bool EvaluateCondition(MonoBehaviour monoBehaviour);


        #region IScriptableObjectContainerSyncReferences

        /// <summary>
        /// Workaround for ObjectReference issues with ScriptableObjects (See ScriptableObjectContainer for details)
        /// </summary>
        /// <param name="objectReferences"></param>
        public virtual void SetReferencesFromContainer(UnityEngine.Object[] objectReferences)
        {
        }

        /// <summary>
        /// Workaround for ObjectReference issues with ScriptableObjects (See ScriptableObjectContainer for details)
        /// </summary>
        public virtual UnityEngine.Object[] GetReferencesForContainer()
        {
            return null;
        }

        #endregion IScriptableObjectContainerSyncReferences
    }
}

using UnityEngine;

namespace Patterns.StructuralPatterns.Proxy
{
    public class Main : MonoBehaviour
    {
		private void Start()
		{
			IDocument adminDoc = new DocumentProxy("Admin");
			IDocument guestDoc = new DocumentProxy("Guest");

			adminDoc.Display();	// 접근 가능
			guestDoc.Display();	// 접근 거부
		}
	}
}
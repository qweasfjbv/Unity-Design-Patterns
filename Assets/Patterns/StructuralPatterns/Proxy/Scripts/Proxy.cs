using UnityEngine;

namespace Patterns.StructuralPatterns.Proxy
{
	public interface IDocument
	{
		void Display();
	}

	public class SecretDocument : IDocument
	{
		public void Display()
		{
			Debug.Log("기밀 문서 표시");
		}
	}

	public class DocumentProxy : IDocument
	{
		SecretDocument document;
		private string userRole;

		public DocumentProxy(string userRole)
		{
			this.userRole = userRole;
		}

		public void Display()
		{
			if (userRole == "Admin")
			{
				if (document == null)
					document = new SecretDocument();

				document.Display();
			}
			else
			{
				Debug.Log("접근 거부");
			}
		}
	}
}

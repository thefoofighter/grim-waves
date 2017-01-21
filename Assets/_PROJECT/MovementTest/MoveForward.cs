using UnityEngine;

public class MoveForward : MonoBehaviour
{
	void Update()
	{
		transform.position = transform.position + new Vector3(0f, 0f, 0.5f);
	}
}

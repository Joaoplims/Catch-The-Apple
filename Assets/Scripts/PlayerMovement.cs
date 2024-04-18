using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform cameraTransform;
    public float movementSmoothness = 2f;
    public float angleTilt = 90f;
    [Header("Limites da Tela")]
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    [Header("Atributos Player")]
    public float speed;

    Vector3 posDestino;

    private void Update()
    {
        posDestino += new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * Time.deltaTime * speed;

        float limiteMinX = cameraTransform.position.x + minX;
        float limiteMaxX = cameraTransform.position.x + maxX;
        float limiteMinZ = cameraTransform.position.z + minZ;
        float limiteMaxZ = cameraTransform.position.z + maxZ;

        posDestino.x = Mathf.Clamp(posDestino.x, limiteMinX, limiteMaxX);
        posDestino.z = Mathf.Clamp(posDestino.z, limiteMinZ, limiteMaxZ);

        transform.position = Vector3.Lerp(transform.position, posDestino, movementSmoothness * Time.deltaTime);

        // rotaciona a nave
        float angle = -Input.GetAxis("Horizontal") * angleTilt;
        float currentZ = transform.localEulerAngles.z;
        float novoZ = Mathf.LerpAngle(currentZ, angle, movementSmoothness * Time.deltaTime);
        transform.localEulerAngles = new Vector3(0f,0f, novoZ);
    }
}

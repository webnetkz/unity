using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
  // Объявляем структуру данных enum, которая будет сопоставлять имена с параметрами.
  public enum RotationAxes {
    MouseXAndY = 0,
    MouseX = 1,
    MouseY = 2
  }
  public float sensitivityHorizontal = 9.0f; // Скорость поворота по горизонтали
  public float sensitivityVertical = 9.0f; // Скорость поворота по вертикали
  public float minimumVertical = -45.0f; // Ограничение на вращение по оси Y
  public float maximumVertical = 45.0f; // Ограничение на вращение по оси X

  private float _rotationX = 0; // Закрытая переменная для угла поворота по вертикали.

  // Объявляем общедоступную переменную, которая появится в редакторе Unity.
  public RotationAxes axes = RotationAxes.MouseXAndY;

  void Update() {
    if(axes == RotationAxes.MouseX) {
      // Поворот по горизонтали
      transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHorizontal * Time.deltaTime, 0);
    } else if(axes == RotationAxes.MouseY) {
      // Это поворот по вертикали
      _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVertical; // Увеличиваем угол поворота по вертикали в соответствии с перемещениями указателя мыши.
      _rotationX = Mathf.Clamp(_rotationX, minimumVertical, maximumVertical); // Фиксируем угол поворота по вертикали в диапазоне, заданном минимальным и максивмальным значениями.
      float rotationY = transform.localEulerAngles.y;

      transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0); // Создаем новый вектор из сохраненных значений поворота.
    } else {
      // Комбинированый поворот
      _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVertical;
      _rotationX = Mathf.Clamp(_rotationX, minimumVertical, maximumVertical);

      float delta = Input.GetAxis("Mouse X") * sensitivityHorizontal; // Значение delta - это величина изменения угла поворота.
      float rotationY = transform.localEulerAngles.y + delta; // Приращение угла поворота через значение delta

      transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

    }
  }
}

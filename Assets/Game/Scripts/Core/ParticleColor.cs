using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColor : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleMain;
    [SerializeField] private ParticleSystem particle1;
    [SerializeField] private ParticleSystem particle2;
    [SerializeField] private ParticleSystem particle3;

    public ParticleSystem ParticleMain { get => particleMain; set => particleMain = value; }

    public void CheckParticelMainColor(WoodType woodType)
    {
        if ((int)woodType == 1)
        {
            var colorModule = ParticleMain.colorOverLifetime;
            colorModule.enabled = true;

            // Tạo gradient với màu đỏ thay vì xanh nhạt
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(Color.red, 0.0f),   // Màu đỏ ngay từ đầu
                new GradientColorKey(new Color(0.8f, 0.2f, 0.2f), 0.25f), // Đỏ hơi đậm hơn
                new GradientColorKey(new Color(0.5f, 0.1f, 0.1f), 1.0f)  // Đỏ đậm dần rồi biến mất
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.25f), // Hiện rõ màu đỏ ở 25%
                new GradientAlphaKey(0.0f, 1.0f)   // Biến mất dần
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 2)
        {
            var colorModule = ParticleMain.colorOverLifetime;
            colorModule.enabled = true;

            // Tạo gradient với màu xanh lá cây thay vì xanh nhạt
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(Color.green, 0.0f),   // Xanh lá cây ngay từ đầu
                new GradientColorKey(new Color(0.0f, 0.8f, 0.0f), 0.25f), // Xanh lá nhạt hơn
                new GradientColorKey(new Color(0.0f, 0.5f, 0.0f), 1.0f)  // Xanh đậm dần rồi biến mất
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.25f), // Hiện rõ màu xanh lá ở 25%
                new GradientAlphaKey(0.0f, 1.0f)   // Biến mất dần
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 3)
        {
            var colorModule = ParticleMain.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mới: Color(0.75f, 0.58f, 0.89f) (Màu tím nhạt)
            Color newColor = new Color(0.75f, 0.58f, 0.89f);

            // Tạo gradient với màu mới
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(newColor, 0.0f),   // Màu tím nhạt ngay từ đầu
                new GradientColorKey(new Color(0.65f, 0.48f, 0.79f), 0.5f), // Đậm dần
                new GradientColorKey(new Color(0.55f, 0.38f, 0.69f), 1.0f)  // Đậm hơn rồi biến mất
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Hiện rõ màu tím nhạt
                new GradientAlphaKey(0.0f, 1.0f)   // Biến mất dần
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 4)
        {
            var colorModule = ParticleMain.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mới: Color(1.0f, 0.71f, 0.76f) (Màu hồng nhạt)
            Color newColor = new Color(1.0f, 0.71f, 0.76f);

            // Tạo gradient với màu mới
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(newColor, 0.0f),   // Màu hồng nhạt lúc bắt đầu
                new GradientColorKey(new Color(0.9f, 0.61f, 0.66f), 0.5f), // Đậm dần
                new GradientColorKey(new Color(0.8f, 0.51f, 0.56f), 1.0f)  // Đậm hơn rồi biến mất
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Hiện rõ màu hồng nhạt
                new GradientAlphaKey(0.0f, 1.0f)   // Biến mất dần
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 5)
        {
            var colorModule = ParticleMain.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mới: Color.yellow (Màu vàng)
            Color newColor = Color.yellow;

            // Tạo gradient với màu vàng
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(newColor, 0.0f),   // Bắt đầu màu vàng tươi
                new GradientColorKey(new Color(1.0f, 0.8f, 0.2f), 0.5f), // Vàng hơi sậm dần
                new GradientColorKey(new Color(1.0f, 0.6f, 0.0f), 1.0f)  // Vàng cam rồi biến mất
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Hiện rõ màu vàng
                new GradientAlphaKey(0.0f, 1.0f)   // Biến mất dần
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 6)
        {
            var colorModule = ParticleMain.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mới: Color.cyan (Xanh lơ)
            Color newColor = Color.cyan;

            // Tạo gradient với màu Cyan
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(newColor, 0.0f),   // Bắt đầu với màu Cyan tươi
                new GradientColorKey(new Color(0.0f, 0.8f, 1.0f), 0.5f), // Cyan hơi sậm dần
                new GradientColorKey(new Color(0.0f, 0.6f, 0.9f), 1.0f)  // Cyan đậm rồi biến mất
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Hiện rõ màu Cyan
                new GradientAlphaKey(0.0f, 1.0f)   // Biến mất dần
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 7)
        {
            var colorModule = ParticleMain.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mới: Cam nhạt (RGB: 1.0, 0.75, 0.5)
            Color newColor = new Color(1.0f, 0.75f, 0.5f);

            // Tạo Gradient với màu cam nhạt
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(newColor, 0.0f),  // Bắt đầu với màu cam nhạt
                new GradientColorKey(new Color(1.0f, 0.6f, 0.3f), 0.5f), // Đậm dần
                new GradientColorKey(new Color(1.0f, 0.5f, 0.2f), 1.0f)  // Chuyển sang cam đậm
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.3f),  // Hiện rõ màu cam
                new GradientAlphaKey(0.0f, 1.0f)   // Biến mất dần
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
    }

    public void CheckParticel1Color(WoodType woodType)
    {
        if ((int)woodType == 1)
        {
            var colorModule = particle1.colorOverLifetime;
            colorModule.enabled = true;

            // Tạo gradient với màu đỏ thay vì xanh nhạt
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
            {
                new GradientColorKey(Color.red, 0.0f),    // Bắt đầu màu đỏ
                new GradientColorKey(new Color(1.0f, 0.4f, 0.4f), 0.5f),  // Giảm sáng nhẹ
                new GradientColorKey(new Color(1.0f, 0.2f, 0.2f), 1.0f)   // Đậm dần rồi biến mất
            },
            new GradientAlphaKey[]
            {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.3f),  // Xuất hiện rõ ràng
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần rồi biến mất
            }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 2)
        {
            var colorModule = particle1.colorOverLifetime;
            colorModule.enabled = true;

            // Tạo gradient với màu xanh lá cây thay vì xanh nhạt
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                 new GradientColorKey[]
            {
                new GradientColorKey(Color.green, 0.0f),    // Bắt đầu màu xanh lá
                new GradientColorKey(new Color(0.4f, 1.0f, 0.4f), 0.5f),  // Xanh sáng hơn
                new GradientColorKey(new Color(0.2f, 0.8f, 0.2f), 1.0f)   // Đậm dần rồi biến mất
            },
            new GradientAlphaKey[]
            {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.3f),  // Xuất hiện rõ ràng
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần rồi biến mất
            }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 3)
        {
            var colorModule = particle1.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mới: Color(0.75f, 0.58f, 0.89f) (Màu tím nhạt)
            Gradient gradient = new Gradient();
            Color purpleLight = new Color(0.75f, 0.58f, 0.89f);

            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(purpleLight, 0.0f),  // Bắt đầu màu tím nhạt
                new GradientColorKey(new Color(0.85f, 0.68f, 0.99f), 0.5f),  // Tím sáng hơn
                new GradientColorKey(new Color(0.65f, 0.48f, 0.79f), 1.0f)   // Tím tối hơn
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.3f),  // Xuất hiện rõ ràng
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần rồi biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 4)
        {
            var colorModule = particle1.colorOverLifetime;
            colorModule.enabled = true;

            Gradient gradient = new Gradient();
            Color pinkLight = new Color(1.0f, 0.71f, 0.76f);

            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(pinkLight, 0.0f),  // Bắt đầu với màu hồng nhạt
                new GradientColorKey(new Color(1.0f, 0.8f, 0.85f), 0.5f),  // Hồng sáng hơn
                new GradientColorKey(new Color(0.9f, 0.6f, 0.7f), 1.0f)   // Hồng tối hơn
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.3f),  // Xuất hiện rõ ràng
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần rồi biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 5)
        {
            var colorModule = particle1.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mới: Color.yellow (Màu vàng)
            Color newColor = Color.yellow;

            // Tạo Gradient với màu vàng (Yellow)
            Gradient gradient = new Gradient();
            Color yellow = Color.yellow; // (1.0f, 0.92f, 0.016f)

            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(yellow, 0.0f),  // Bắt đầu với màu vàng
                new GradientColorKey(new Color(1.0f, 1.0f, 0.6f), 0.5f),  // Vàng nhạt hơn
                new GradientColorKey(new Color(1.0f, 0.85f, 0.0f), 1.0f)   // Vàng đậm hơn
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.3f),  // Xuất hiện rõ ràng
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần rồi biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 6)
        {
            var colorModule = particle1.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mới: Color.cyan (Xanh lơ)
            Gradient gradient = new Gradient();
            Color cyan = Color.cyan; // (0.0f, 1.0f, 1.0f)

            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(cyan, 0.0f),  // Bắt đầu với màu Cyan tươi
                new GradientColorKey(new Color(0.5f, 1.0f, 1.0f), 0.5f),  // Cyan nhạt
                new GradientColorKey(new Color(0.0f, 0.8f, 0.8f), 1.0f)   // Cyan đậm hơn
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.3f),  // Xuất hiện rõ ràng
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần rồi biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 7)
        {
            var colorModule = particle1.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mới: Cam nhạt (RGB: 1.0, 0.75, 0.5)
            Color newColor = new Color(1.0f, 0.75f, 0.5f);

            // Tạo Gradient với màu Color(1.0f, 0.75f, 0.5f)
            Gradient gradient = new Gradient();
            Color targetColor = new Color(1.0f, 0.75f, 0.5f); // Màu cam nhạt

            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(targetColor, 0.0f),  // Bắt đầu với màu cam nhạt
                new GradientColorKey(new Color(1.0f, 0.85f, 0.6f), 0.5f),  // Màu cam sáng hơn
                new GradientColorKey(new Color(0.9f, 0.65f, 0.4f), 1.0f)   // Màu cam đậm hơn
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.3f),  // Xuất hiện rõ ràng
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần rồi biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
    }

    public void CheckParticel2Color(WoodType woodType)
    {
        if ((int)woodType == 1)
        {
            var colorModule = particle2.colorOverLifetime;
            colorModule.enabled = true;

            // Tạo gradient với màu đỏ thay vì xanh nhạt
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(Color.red, 0.0f),  // Bắt đầu màu đỏ
                new GradientColorKey(new Color(1.0f, 0.3f, 0.3f), 0.5f),  // Giữa: Đỏ nhạt
                new GradientColorKey(new Color(1.0f, 0.6f, 0.6f), 1.0f)   // Cuối: Nhạt dần trước khi biến mất
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Xuất hiện rõ
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần và biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 2)
        {
            var colorModule = particle2.colorOverLifetime;
            colorModule.enabled = true;

            // Tạo Gradient chuyển từ xanh đậm -> xanh nhạt -> biến mất
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(Color.green, 0.0f),  // Bắt đầu màu xanh lá
                new GradientColorKey(new Color(0.3f, 1.0f, 0.3f), 0.5f),  // Giữa: Xanh nhạt
                new GradientColorKey(new Color(0.6f, 1.0f, 0.6f), 1.0f)   // Cuối: Xanh rất nhạt trước khi biến mất
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Xuất hiện rõ
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần và biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 3)
        {
            var colorModule = particle2.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mục tiêu: Color(0.75f, 0.58f, 0.89f) (Tím nhạt)
            Color targetColor = new Color(0.75f, 0.58f, 0.89f);

            // Tạo Gradient chuyển từ tím nhạt -> tím nhạt hơn -> mờ dần
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(targetColor, 0.0f),  // Bắt đầu: Tím nhạt
                new GradientColorKey(new Color(0.85f, 0.68f, 0.99f), 0.5f),  // Giữa: Tím nhạt hơn
                new GradientColorKey(new Color(0.92f, 0.78f, 1.0f), 1.0f)   // Cuối: Gần như trắng
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Xuất hiện rõ
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần và biến mất
                }
            );


            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 4)
        {
            var colorModule = particle2.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mục tiêu: Hồng nhạt (Color(1.0f, 0.71f, 0.76f))
            Color targetColor = new Color(1.0f, 0.71f, 0.76f);

            // Tạo Gradient chuyển từ hồng nhạt -> nhạt hơn -> biến mất
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(targetColor, 0.0f),  // Bắt đầu: Hồng nhạt
                new GradientColorKey(new Color(1.0f, 0.8f, 0.85f), 0.5f),  // Giữa: Nhạt hơn
                new GradientColorKey(new Color(1.0f, 0.9f, 0.95f), 1.0f)   // Cuối: Gần như trắng
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Xuất hiện rõ
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần và biến mất
                }
            );


            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 5)
        {
            var colorModule = particle2.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mục tiêu: Vàng (Yellow)
            Color targetColor = Color.yellow;

            // Tạo Gradient chuyển từ vàng → nhạt hơn → biến mất
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(targetColor, 0.0f),  // Bắt đầu: Vàng
                new GradientColorKey(new Color(1.0f, 1.0f, 0.7f), 0.5f),  // Giữa: Vàng nhạt
                new GradientColorKey(new Color(1.0f, 1.0f, 0.9f), 1.0f)   // Cuối: Gần như trắng
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Xuất hiện rõ
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần và biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 6)
        {
            var colorModule = particle2.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mục tiêu: Cyan
            Color targetColor = Color.cyan;

            // Tạo Gradient chuyển từ Cyan → nhạt dần → biến mất
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(targetColor, 0.0f),  // Bắt đầu: Cyan
                new GradientColorKey(new Color(0.6f, 1.0f, 1.0f), 0.5f),  // Giữa: Cyan nhạt
                new GradientColorKey(new Color(0.8f, 1.0f, 1.0f), 1.0f)   // Cuối: Gần như trắng
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Xuất hiện rõ
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần và biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 7)
        {
            var colorModule = particle2.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mục tiêu: Color(1.0f, 0.75f, 0.5f)
            Color targetColor = new Color(1.0f, 0.75f, 0.5f);

            // Tạo Gradient chuyển từ Cam nhạt → Nhạt dần → Biến mất
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(targetColor, 0.0f),  // Bắt đầu: Cam nhạt
                new GradientColorKey(new Color(1.0f, 0.85f, 0.65f), 0.5f),  // Giữa: Cam rất nhạt
                new GradientColorKey(new Color(1.0f, 0.9f, 0.8f), 1.0f)   // Cuối: Gần như trắng
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Xuất hiện rõ
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần và biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
    }

    public void CheckParticel3Color(WoodType woodType)
    {
        if ((int)woodType == 1)
        {
            var colorModule = particle3.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mục tiêu: Đỏ
            Color targetColor = Color.red;

            // Tạo Gradient chuyển từ Đỏ → Nhạt dần → Biến mất
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(targetColor, 0.0f),  // Bắt đầu: Đỏ
                new GradientColorKey(new Color(1.0f, 0.5f, 0.5f), 0.5f),  // Giữa: Đỏ nhạt
                new GradientColorKey(new Color(1.0f, 0.8f, 0.8f), 1.0f)   // Cuối: Gần như trắng
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Xuất hiện rõ
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần và biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 2)
        {
            var colorModule = particle3.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mục tiêu: Xanh lá
            Color targetColor = Color.green;

            // Tạo Gradient chuyển từ Xanh lá → Nhạt dần → Biến mất
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(targetColor, 0.0f),  // Bắt đầu: Xanh lá
                new GradientColorKey(new Color(0.5f, 1.0f, 0.5f), 0.5f),  // Giữa: Xanh lá nhạt
                new GradientColorKey(new Color(0.8f, 1.0f, 0.8f), 1.0f)   // Cuối: Gần như trắng
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Xuất hiện rõ
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần và biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 3)
        {
            var colorModule = particle3.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mục tiêu: Màu tím nhạt (0.75, 0.58, 0.89)
            Color targetColor = new Color(0.75f, 0.58f, 0.89f);

            // Tạo Gradient chuyển từ Màu tím nhạt → Mờ dần → Biến mất
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(targetColor, 0.0f),  // Bắt đầu: Màu tím nhạt
                new GradientColorKey(new Color(0.85f, 0.68f, 0.95f), 0.5f),  // Giữa: Tím sáng hơn
                new GradientColorKey(new Color(0.95f, 0.78f, 1.0f), 1.0f)   // Cuối: Gần như trắng
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Xuất hiện rõ
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần và biến mất
                }
            );


            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 4)
        {
            var colorModule = particle3.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mục tiêu: Hồng nhạt (1.0f, 0.71f, 0.76f)
            Color targetColor = new Color(1.0f, 0.71f, 0.76f);

            // Tạo Gradient chuyển từ Hồng nhạt → Hồng nhạt sáng hơn → Gần như trắng
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(targetColor, 0.0f),  // Bắt đầu: Hồng nhạt
                new GradientColorKey(new Color(1.0f, 0.8f, 0.85f), 0.5f),  // Giữa: Hồng sáng hơn
                new GradientColorKey(new Color(1.0f, 0.9f, 0.95f), 1.0f)   // Cuối: Gần như trắng
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Xuất hiện rõ
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần và biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 5)
        {
            var colorModule = particle3.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mục tiêu: Vàng (Yellow)
            Color targetColor = Color.yellow;

            // Tạo Gradient chuyển từ Vàng đậm → Vàng sáng → Trắng nhạt dần
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(targetColor, 0.0f),  // Bắt đầu: Vàng
                new GradientColorKey(new Color(1.0f, 1.0f, 0.7f), 0.5f),  // Giữa: Vàng nhạt hơn
                new GradientColorKey(new Color(1.0f, 1.0f, 0.9f), 1.0f)   // Cuối: Gần như trắng
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Xuất hiện rõ
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần và biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 6)
        {
            var colorModule = particle3.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mục tiêu: Cyan
            Color targetColor = Color.cyan;

            // Tạo Gradient chuyển từ Cyan đậm → Cyan nhạt → Trắng dần
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(targetColor, 0.0f),  // Bắt đầu: Cyan
                new GradientColorKey(new Color(0.7f, 1.0f, 1.0f), 0.5f),  // Giữa: Cyan nhạt hơn
                new GradientColorKey(new Color(0.9f, 1.0f, 1.0f), 1.0f)   // Cuối: Gần như trắng
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Xuất hiện rõ
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần và biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
        else if ((int)woodType == 7)
        {
            var colorModule = particle3.colorOverLifetime;
            colorModule.enabled = true;

            // Màu mục tiêu: Color(1.0f, 0.75f, 0.5f)
            Color targetColor = new Color(1.0f, 0.75f, 0.5f);

            // Tạo Gradient chuyển từ màu targetColor đậm → nhạt dần → gần trắng
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[]
                {
                new GradientColorKey(targetColor, 0.0f),  // Bắt đầu: Màu cam nhạt
                new GradientColorKey(new Color(1.0f, 0.85f, 0.7f), 0.5f),  // Giữa: Nhạt hơn
                new GradientColorKey(new Color(1.0f, 0.95f, 0.9f), 1.0f)   // Cuối: Gần trắng
                },
                new GradientAlphaKey[]
                {
                new GradientAlphaKey(0.0f, 0.0f),  // Bắt đầu trong suốt
                new GradientAlphaKey(1.0f, 0.2f),  // Xuất hiện rõ ràng
                new GradientAlphaKey(0.0f, 1.0f)   // Mờ dần và biến mất
                }
            );

            // Áp dụng Gradient vào Color Over Lifetime
            colorModule.color = new ParticleSystem.MinMaxGradient(gradient);
        }
    }
}

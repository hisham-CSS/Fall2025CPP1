using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class BasicPlayerControllerTests
{
    private GameObject player;
    private PlayerController controller;

    [SetUp]
    public void Setup()
    {
        // Create a new GameObject and add the PlayerController component
        player = new GameObject();

        player.AddComponent<Rigidbody2D>();
        player.AddComponent<BoxCollider2D>();
        player.AddComponent<SpriteRenderer>();
        player.AddComponent<Animator>();

        controller = player.AddComponent<PlayerController>();
    }

    [TearDown]
    public void Teardown()
    {
        // Destroy the GameObject after each test
        Object.DestroyImmediate(player);
    }

    [Test]
    public void PlayerController_InitalJumpForce_IsSetCorrectly()
    {
        // Arrange
        float expectedJumpForce = 7f;
        // Act
        float actualJumpForce = controller.jumpForce;
        // Assert
        Assert.AreEqual(expectedJumpForce, actualJumpForce);
    }

    [Test]
    public void PlayerController_ActivateJumpForceChange_ChangesJumpForce()
    {
        // Arrange
        float expectedJumpForce = 10f;
        // Act
        controller.ApplyJumpForcePowerup();
        float changedJumpForce = controller.jumpForce;
        // Assert
        Assert.AreEqual(changedJumpForce, expectedJumpForce);
    }

    [UnityTest]
    public System.Collections.IEnumerator PlayerController_JumpForcePowerupTimer_WorksCorrectly()
    {
        // Arrange
        float initialJumpForce = controller.jumpForce;
        controller.ApplyJumpForcePowerup();
        // Act
        yield return new WaitForSecondsRealtime(controller.initalPowerUpTimer + 0.1f);
        float finalJumpForce = controller.jumpForce;
        // Assert
        Assert.AreEqual(initialJumpForce, finalJumpForce);
    }
}

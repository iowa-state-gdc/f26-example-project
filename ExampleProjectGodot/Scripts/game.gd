extends Node2D

# A reference to the prefab (scene) which defines a brick
@export var brick_prefab : PackedScene

# Create all of our bricks
func init_bricks() -> void:
	for x : int in range(-5, 5):
		for y : int in 10:
			# Create a new brick
			var brick : Brick = brick_prefab.instantiate()
			
			# Position the brick on the board
			brick.position = Vector2(-60 * x - 30, 30 * y - 580)
			
			# Add the brick to the scene
			call_deferred("add_child", brick)
			
			# Color the brick based on its relative position
			brick.call_deferred("set_color", Color(1.0 - 0.1 * y, 0.1 * y, 0.2 + 0.1 * (x & 1)))

# Called when this node is created
func _ready() -> void:
	init_bricks()

# The update/tick function
func _process(_delta : float) -> void:
	# If the player wants to reset
	if Input.is_action_just_pressed("reset"):
		# Reset the board
		get_tree().reload_current_scene()

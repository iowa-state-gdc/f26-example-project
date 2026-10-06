extends RigidBody2D

# A reference to the player's paddle in the scene
@export var paddle_ref : Node2D

# The speed the ball moves at in pixels per second
@export var speed : float = 300.

# A flag for whether or not the ball has been thrown
var thrown : bool = false

# The update/tick function
func _process(_delta: float) -> void:
	# When the player throws the ball
	if Input.is_action_just_pressed("throw_ball") and not thrown:
		# Mark the ball as thrown
		thrown = true
		
		# Make the ball move upwards
		linear_velocity = Vector2(0, -speed)
	
	# If the ball has not been thrown yet
	if not thrown:
		# Make the ball follow the player's paddle
		position.x = paddle_ref.position.x
	# If the ball has been thrown and reaches the bottom of the board
	elif position.y > -16:
		# Restart
		get_tree().reload_current_scene()

# Is called when the ball collides with something
func _on_collision(other : Node) -> void:
	# If we hit a brick
	if other is Brick:
		# Destroy it!
		other.queue_free()
	
	# If we hit a paddle
	if other is Paddle:
		# Influence our velocity slightly based off of our paddle's movement
		linear_velocity = linear_velocity.normalized() + Vector2(other.delta_x, 0).normalized() / 2
	
	# Rescale our velocity to our move speed
	linear_velocity = linear_velocity.normalized() * speed

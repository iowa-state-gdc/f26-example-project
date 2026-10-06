class_name Paddle extends AnimatableBody2D

# The percentage of the board width moved per second
@export var move_speed_per_second : float = 1.

# The current position as a percentage of board crossed
var h_pos : float = 0.5

# A record of our change in horizontal position
var delta_x : float = 0.

# The update/tick function
func _process(delta: float) -> void:
	# Store our initial horizontal position
	var initial_h_pos : float = h_pos
	
	# When the player moves left
	if Input.is_action_pressed("paddle_left"):
		# Move left at a rate of move_speed_per_second, clamped to the board space
		h_pos = maxf(h_pos - move_speed_per_second * delta, 0.0)
	
	# When the player moves right
	if Input.is_action_pressed("paddle_right"):
		# Move right at a rate of move_speed_per_second, clamped to the board space
		h_pos = minf(h_pos + move_speed_per_second * delta, 1.0)
	
	# Move the paddle to its new horizontal position
	position.x = 500. * (h_pos - 0.5)
	
	# Compute our change in horizontal position
	delta_x = h_pos - initial_h_pos

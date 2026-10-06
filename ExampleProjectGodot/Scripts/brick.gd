class_name Brick extends StaticBody2D

# A reference to the node displaying the brick's color
@onready var img : ColorRect = $Image

# Change the color of this brick
func set_color(c : Color) -> void:
	img.color = c

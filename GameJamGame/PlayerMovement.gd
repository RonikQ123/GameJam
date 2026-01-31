extends KinematicBody2D

export var speed := 140

func _physics_process(_delta):
	var dir := Vector2.ZERO

	dir.x = Input.get_action_strength("move_right") - Input.get_action_strength("move_left")
	dir.y = Input.get_action_strength("move_down") - Input.get_action_strength("move_up")
	dir = dir.normalized()

	move_and_slide(dir * speed)

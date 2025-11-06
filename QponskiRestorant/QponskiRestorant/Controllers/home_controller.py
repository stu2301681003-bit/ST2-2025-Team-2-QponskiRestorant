from flask import Blueprint, render_template

home_bp = Blueprint('home', __name__)

@home_bp.route('/')
def home():
    """
    Начална страница на японския ресторант.
    """
    return render_template('home_view.html', title="Японски ресторант", welcome_message="Добре дошли в нашия японски ресторант!")

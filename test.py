class SingletonMeta(type):
    _instances = {}

    def __call__(cls, *args, **kwargs):
        if cls not in cls._instances:
            cls._instances[cls] = super(SingletonMeta, cls).__call__(*args, **kwargs)
        return cls._instances[cls]

class SingletonClass(metaclass=SingletonMeta):
    def __init__(self):
        self.value = None

    def set_value(self, value):
        self.value = value

    def get_value(self):
        return self.value

# Example usage:
instance1 = SingletonClass()
instance1.set_value("Hello, Singleton!")

instance2 = SingletonClass()
print(instance2.get_value())  # Output: "Hello, Singleton!"

# Check if both instances are the same object
print(instance1 is instance2)  # Output: True

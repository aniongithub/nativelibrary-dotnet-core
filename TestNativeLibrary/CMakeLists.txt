cmake_minimum_required(VERSION 3.0)

project(TestNativeLibrary C)

# Add executable target
add_executable(${PROJECT_NAME} main.c)

add_dependencies(${PROJECT_NAME} NativeLibrary)

target_link_libraries(${PROJECT_NAME} dl)
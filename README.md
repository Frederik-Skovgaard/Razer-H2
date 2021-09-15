# Introduction
This is a project, is a razor pages project...... SOOO yeah.. cool

# Shortcuts
*  **Change Log Updates**
	 * [Version 0.3.0](#Version-0.1.0)
	 * [Version 0.2.0](#Version-0.1.0)
	 * [Version 0.1.0](#Version-0.1.0)
* **Infomation**
	* [Methods Used](#Methods-Used)
		* [OnPostCreate](#OnPostCreate)
		* [OnPostUpdate](#OnPostUpdate)
		* [OnPostDelete](#OnPostDelete)


# Methods Used
### OnPostCreate
* Gets Todo object from index and adds it to the Todo lists.
### OnPostUpdate
* Gets ID from index & uses it to find the Todo, and then updates all parameters.
### OnPostDelete
* Gets ID from index & uses it to find the Todo, and then delete it from the Todo list.

# Change log
# [Unreleased]
## [Version 0.3.0](https://github.com/CarfloHD/Razer-H2/compare/Version-0.2.0...Version-0.3.0) 14-09-2021
### Added
- [x] Save button to check if IsComplet was check.
- [x] Load button to show completed todos.
- [x] Edit button to edit selected todo.
- [x] Edit page for editing todos.
- [x] Styling for edit page & buttons.
### Changed
- [x] Styling of entire page.
- [x]  Show todos by oldest first.
## [Version 0.2.0](https://github.com/CarfloHD/Razer-H2/compare/Version-0.1.0...Version-0.2.0) 13-09-2021
### Added
- [x] Button for opening modal.
- [x] Modal for adding Todo .
- [x] Styling for modal.
### Changed 
- [x] Styling on Todo list container.
## Version 0.1.0 10-09-2021
### Added
- [x] Class ToDo .
- [x] Todo Repository.
- [x] Method for creating, deleteting & updating.
- [x] Method for reading Todo list to index list & finding Todo by id.
- [x] Container for displaying Todo from list & styling.

# MvvmLight.RollbackViewModel
Library for reverting viewModel changes

**Info**

This is extension PCL library for MvvmLight (http://www.mvvmlight.net/)

**How it works**

Library saves (clone) current ViewModel to temporary variable.

When ViewModel rollback is needed, program will iterate through all properties (except with SkipRollbackAttribute) and set values from cloned (original) ViewModel.

**Example**

Solution contains "Settings example" project.

You can change application theme in settings window.

When you cancel setting window, library will set original values.

For this example was used awesome framework MahApps (http://mahapps.com/)
